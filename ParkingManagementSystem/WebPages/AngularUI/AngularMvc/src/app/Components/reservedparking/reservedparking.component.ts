import { Component } from '@angular/core';
import { ReservedServiceService } from 'src/app/Services/ReservedParking/reserved-service.service';
import { ReservedModel } from 'src/app/Models/reserved/reserved.module';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-reservedparking',
  templateUrl: './reservedparking.component.html',
  styleUrls: ['./reservedparking.component.css'],
})
export class ReservedparkingComponent {
  formData: ReservedModel = {
    rpid: '',
    email: '',
    phoneNo: '',
    slot: '',
    vehicleNo: '',
    identifications: '',
    category: '',
    name: '',
    address: '',
  };

  constructor(
    private reservedService: ReservedServiceService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    // Retrieve query parameters and autofill the form fields
    const pidParam = this.activatedRoute.snapshot.queryParamMap.get('pid');
    const slotParam = this.activatedRoute.snapshot.queryParamMap.get('slot');

    this.formData.rpid = pidParam || '';
    this.formData.slot = slotParam || '';
  }

  reserveParking() {
    const slotsData = {
      two: true,
      three: true,
      six: true,
      twelve: true,
      day: true,
    };
    this.reservedService
      .updateParkingSlots(this.formData.slot, slotsData)
      .subscribe(
        (updateResponse) => {
          console.log('Parking slots updated successfully:', updateResponse);

          this.reservedService.createReservedParking(this.formData).subscribe(
            (reservationResponse) => {
              console.log('Reservation successful:', reservationResponse);
            },
            (reservationError) => {
              console.error('Error creating reservation:', reservationError);
            }
          );
        },
        (updateError) => {
          console.error('Error updating parking slots:', updateError);
        }
      );
  }
}
