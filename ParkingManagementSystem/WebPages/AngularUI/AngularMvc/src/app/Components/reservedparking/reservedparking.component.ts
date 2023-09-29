import { Component } from '@angular/core';
import { ReservedServiceService } from 'src/app/Services/ReservedParking/reserved-service.service';
import {
  ReservedModel,
  Rtransferdata,
} from 'src/app/Models/reserved/reserved.module';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';
import { formatDate } from '@angular/common';
import { SlotModel } from 'src/app/Models/availability/availability.module';
import { HttpClient } from '@angular/common/http';
import { SharedService } from 'src/app/Services/shared/shared.service';
import { AuthenticationsService } from 'src/app/Services/Login/authentications.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';

const slotDictionary: { [key: string]: string } = {
  Block1: 'two',
  Block2: 'three',
  Block3: 'six',
  Block4: 'twelve',
  Block5: 'day',
};
@Component({
  selector: 'app-reservedparking',
  templateUrl: './reservedparking.component.html',
  styleUrls: ['./reservedparking.component.css'],
})
export class ReservedparkingComponent {
  reservationForm: FormGroup;
  price: number = 0;
  pprice: number[] = [];
  rTransferData: Rtransferdata = {
    rpid: '',
    userID: this.authService.getEmailFromToken(),
    amount: 0,
    paymentDate: new Date(),
  };
  formData: ReservedModel = {
    rpid: this.generateRandomString(5),
    email: '',
    phoneNo: '',
    slot: '',
    vehicleNo: '',
    identifications: '',
    category: '',
    name: '',
    address: '',
    pkid: '',
    CheckIn: '',
    checkout: '',
  };

  constructor(
    private reservedService: ReservedServiceService,
    private activatedRoute: ActivatedRoute,
    private httpClient: HttpClient,
    private sharedService: SharedService,
    private router: Router,
    private authService: AuthenticationsService,
    private formBuilder: FormBuilder
  ) {
    this.reservationForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: [
        '',
        [
          Validators.required,
          Validators.email,
          Validators.pattern(
            '[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}'
          ),
        ],
      ],
      slotNumber: [{ value: '', disabled: true }, Validators.required],
      vehicleNumber: ['', Validators.required],
      category: ['', Validators.required],
      idProof: ['', Validators.required],
      phoneNumber: ['', [Validators.required, Validators.pattern('[0-9]{10}')]],
      address: ['', Validators.required],
      CheckIn: ['', Validators.required],
      checkout: ['', Validators.required],
    });
  }

  ngOnInit() {
    const pidParam = this.activatedRoute.snapshot.queryParamMap.get('pid');
    const slotParam = this.activatedRoute.snapshot.queryParamMap.get('slot');
    this.formData.pkid = pidParam || '';
    this.formData.slot = slotParam || '';
  }
  updatePayment(amounts: number) {
    const checkInTime = this.reservationForm.get('CheckIn')?.value;
    const checkOutTime = this.reservationForm.get('checkout')?.value;

    if (checkInTime && checkOutTime) {
      const checkIn = new Date(`1970-01-01T${checkInTime}`);
      const checkOut = new Date(`1970-01-01T${checkOutTime}`);
      const timeDifference = checkOut.getTime() - checkIn.getTime();
      const minutesDifference = timeDifference / (1000 * 60);
      const pricePerMinute = amounts / 60;
      const amount = Math.round(minutesDifference * pricePerMinute);
      this.price = amount;
      this.pprice.push(amount);
      this.rTransferData.amount = amount;
      console.log(this.price);

      this.router.navigate(['/Payment'], {
        queryParams: {
          amount: this.price,
          rpid: this.formData.rpid,
        },
      });
    }
  }

  generateRandomString(length: number): string {
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    let result = '';
    for (let i = 0; i < length; i++) {
      const randomIndex = Math.floor(Math.random() * characters.length);
      result += characters.charAt(randomIndex);
    }
    return result;
  }

  updateParkingSlots() {
    const pid = this.formData.pkid;
    const slotToUpdate = slotDictionary[this.formData.slot];

    this.reservedService.getParkingSlotData(pid).subscribe(
      (currentSlotData) => {
        this.price = currentSlotData.pricePerHour;
        this.updatePayment(this.price);
        if (currentSlotData && currentSlotData.hasOwnProperty(slotToUpdate)) {
          currentSlotData[slotToUpdate] = currentSlotData[slotToUpdate] + 1;

          this.reservedService
            .updateParkingSlots(pid, currentSlotData)
            .subscribe(
              (updateResponse) => {
                console.log(
                  'Parking slot updated successfully:',
                  updateResponse
                );
              },
              (updateError) => {
                console.error('Error updating parking slot:', updateError);
              }
            );
        } else {
          console.error(`Slot '${slotToUpdate}' not found in currentSlotData.`);
        }
      },
      (error) => {
        console.error('Error fetching parking slot data:', error);
      }
    );
  }

  createReservedParking() {
    console.log(this.formData);
    this.reservedService.createReservedParking(this.formData).subscribe(
      (reservationResponse) => {
        console.log('Reservation successful:', reservationResponse);
      },
      (reservationError) => {
        console.error('Error creating reservation:', reservationError);
      }
    );
  }

  reserveParking() {
    this.formData.name = this.reservationForm.get('name')?.value;
    this.formData.email = this.reservationForm.get('email')?.value;
    this.formData.vehicleNo = this.reservationForm.get('vehicleNumber')?.value;
    this.formData.category = this.reservationForm.get('category')?.value;
    this.formData.identifications = this.reservationForm.get('idProof')?.value;
    this.formData.phoneNo = this.reservationForm.get('phoneNumber')?.value;
    this.formData.address = this.reservationForm.get('address')?.value;
    this.formData.CheckIn = this.reservationForm.get('CheckIn')?.value;
    this.formData.checkout = this.reservationForm.get('checkout')?.value;

    if (this.reservationForm.invalid) {
      this.showNotification('Please fill all details', 'failure');
      return;
    }

    this.updateParkingSlots();
    this.createReservedParking();
  }

  showNotification(message: string, type: string) {
    Swal.fire({
      icon: type === 'success' ? 'success' : 'error',
      title: message,
      showConfirmButton: false,
      timer: 2000,
    });
  }
}
