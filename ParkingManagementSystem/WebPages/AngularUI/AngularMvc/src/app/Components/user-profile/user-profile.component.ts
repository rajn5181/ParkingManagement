import { Component, OnInit } from '@angular/core';
import { UserProfile } from 'src/app/Models/userprofile/userprofile.module';
import { AuthenticationsService } from 'src/app/Services/Login/authentications.service';
import { PaymentdetailsService } from 'src/app/Services/Payments/paymentdetails.service';
import { ReservedServiceService } from 'src/app/Services/ReservedParking/reserved-service.service';
import { UserProfileService } from 'src/app/Services/UserProfile/user-profile.service';

import Swal from 'sweetalert2';
const slotDictionary: { [key: string]: string } = {
  Block1: 'two',
  Block2: 'three',
  Block3: 'six',
  Block4: 'twelve',
  Block5: 'day',
};
@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
})
export class UserProfileComponent implements OnInit {
  dtoptions: DataTables.Settings = {};
  userProfile: UserProfile | undefined;
  profiledata: any;
  userId: string = '';
  userIDD: string = this.authService.getEmailFromToken();
  bookingDetails: any;

  constructor(
    private userProfileService: UserProfileService,
    private authService: AuthenticationsService,
    private reservedService: ReservedServiceService,
    private paymentservice: PaymentdetailsService
  ) {}

  ngOnInit() {
    this.dtoptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      lengthMenu: [10, 25, 50, 100],
      searching: true,
      ordering: true,
      info: true,
      autoWidth: false,
      responsive: true,
    };
    const userId = this.authService.getEmailFromToken();
    this.userProfileService.fetchUserProfile(userId).subscribe((data) => {
      this.profiledata = data;
    });
    this.GetUserBookDetails();
  }
  GetUserBookDetails() {
    this.userProfileService.fetchUserData(this.userIDD).subscribe((data) => {
      if (!data) {
        this.showNotification('You do not have booking!', 'failure');
      } else {
        this.userId = this.userIDD;
        this.userProfile = data;
        this.bookingDetails = data;
        // console.log(this.bookingDetails);
      }
    });
  }
  updateParkingSlots() {
    if (this.bookingDetails) {
      const slotToUpdate = slotDictionary[this.bookingDetails[0].slot];

      const pkid = this.bookingDetails[0].pkid;

      this.reservedService.getParkingSlotData(pkid).subscribe(
        (currentSlotData) => {
          if (currentSlotData && currentSlotData.hasOwnProperty(slotToUpdate)) {
            currentSlotData[slotToUpdate] = currentSlotData[slotToUpdate] - 1;
            this.reservedService
              .updateParkingSlots(pkid, currentSlotData)
              .subscribe(
                (updateResponse) => {
                  this.showNotification(
                    'Parking Slot delete successfully',
                    'success'
                  );
                },
                (updateError) => {
                  console.error('Error updating parking slot:', updateError);
                }
              );
          } else {
            console.error(
              `Slot '${slotToUpdate}' not found in currentSlotData.`
            );
          }
        },
        (error) => {
          console.error('Error fetching parking slot data:', error);
        }
      );
    }
  }

  cancelBooking(rpid: string) {
    this.reservedService.deleteReserved(rpid).subscribe((response) => {
      console.log(response);
    });
    this.paymentservice.DeletePaymentById(rpid).subscribe((data) => {
      console.log(data);
    });
    this.updateParkingSlots();
  }
  ngAfterViewInit() {}
  showNotification(message: string, type: string) {
    Swal.fire({
      icon: type === 'success' ? 'success' : 'error',
      title: message,
      showConfirmButton: false,
      timer: 3000,
    });
  }
}
