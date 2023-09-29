//availability components.ts
import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/Services/shared/shared.service';
import { ParkingavailableService } from 'src/app/Services/Parkingavailable/parkingavailable.service';
import {
  Availability,
  SlotModel,
} from 'src/app/Models/availability/availability.module';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-availability',
  templateUrl: './availability.component.html',
  styleUrls: ['./availability.component.css'],
})
export class AvailabilityComponent implements OnInit {
  selectedDate: Date;
  formatdate: string | undefined;
  parkingData: Availability[] = [];
  searchLocation: string = '';

  constructor(
    private parkingService: ParkingavailableService,
    private router: Router,
    private sharedService: SharedService,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) {
    this.selectedDate = new Date();
  }

  ngOnInit() {
    // this.captureDate();
  }

  captureDate() {
    const isoDate = this.selectedDate;
    this.formatdate = isoDate.toString();
    this.getParkingData(this.formatdate);
  }

  getParkingData(date: string) {
    this.parkingService.getDataByDate(date).subscribe(
      (data: Availability) => {
        const pid = data.Pid;
        this.sharedService.setParkingData(data);
        this.router.navigate(['/ParkingAvailable']);
      },
      (error) => {
        if (error.status === 404) {
          this.showNotification(
            'Parking data not found for this date. Please try a different date.',
            'failure'
          );
        } else {
          this.showNotification(
            'An error occurred while fetching parking data. Please try again later.',
            'failure'
          );
        }
      }
    );
  }
  searchByLocation(location: string) {
    this.parkingService.searchByLocation(location).subscribe(
      (data: Availability[]) => {
        this.sharedService.setParkingData(data);
        this.router.navigate(['/ParkingAvailable']);
      },
      (error) => {
        if (error.status === 404) {
          this.showNotification(
            'Parking data not found for this location. Please try a different locations.',
            'failure'
          );
        } else {
          this.showNotification(
            'An error occurred while fetching parking data. Please try again later.',
            'failure'
          );
        }
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
