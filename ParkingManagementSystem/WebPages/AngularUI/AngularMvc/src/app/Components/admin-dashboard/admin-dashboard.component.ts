import { Component } from '@angular/core';
import { AdminParkinslotService } from 'src/app/Services/AdminParkingM/admin-parkinslot.service';
import { AuthenticationsService } from 'src/app/Services/Login/authentications.service';
import { UserProfileService } from 'src/app/Services/UserProfile/user-profile.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
})
export class AdminDashboardComponent {
  userIDD: string = this.authService.getEmailFromToken();
  profiledata: any;
  getparkingData: any;
  formData = {
    pid: '',
    status: false,
    slots: [
      {
        id: '',
        two: 0,
        three: 0,
        six: 0,
        twelve: 0,
        day: 0,
        limit_Block1: 0,
        limit_Block2: 0,
        limit_Block3: 0,
        limit_Block4: 0,
        limit_Block5: 0,
        pricePerHour: 0,
      },
    ],
    available: '',
    location: '',
  };
  constructor(
    private adminService: AdminParkinslotService,
    private authService: AuthenticationsService,
    private userProfileService: UserProfileService
  ) {}
  ngOnInit() {
    const userId = this.authService.getEmailFromToken();
    this.userProfileService.fetchUserProfile(userId).subscribe((data) => {
      this.profiledata = data;
    });
  }
  onSubmit() {
    console.log(this.formData);
    this.adminService.createReservedParking(this.formData).subscribe(
      (response) => {
        this.getParkingSlotData(this.formData.pid);
        this.showNotification(
          'Your Parking Slots Created! Successfully',
          'success'
        );
      },
      (error) => {
        this.showNotification('Pakring slots is not created!', 'failure');
      }
    );
  }
  getParkingSlotData(id: string) {
    this.adminService.getParkingSlotData(id).subscribe(
      (data) => {
        console.log(data);
        this.getparkingData = data;
        console.log(this.getparkingData);
        console.log('Parking slot data:', data);
      },
      (error) => {
        console.error('Error fetching parking slot data:', error);
      }
    );
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
