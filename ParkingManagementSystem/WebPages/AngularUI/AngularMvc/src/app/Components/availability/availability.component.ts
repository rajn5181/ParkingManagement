//availability components.ts
import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/Services/shared/shared.service';
import { ParkingavailableService } from 'src/app/Services/Parkingavailable/parkingavailable.service';
import {
  Availability,
  SlotModel,
} from 'src/app/Models/availability/availability.module'; // Import your model
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

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
    private route: ActivatedRoute
  ) {
    this.selectedDate = new Date();
  }

  ngOnInit() {
    this.captureDate();
  }

  captureDate() {
    const isoDate = this.selectedDate.toISOString();
    const datePart = isoDate.split('T')[0];
    this.formatdate = datePart;
    this.getParkingData(this.formatdate);
  }

  getParkingData(date: string) {
    this.parkingService.getDataByDate(date).subscribe(
      (data: Availability) => {
        const pid = data.Pid;
        this.sharedService.setParkingData(data);
        this.router.navigate(['/ParkingAvailable']);
      },
      (error) => {}
    );
  }
  searchByLocation(location: string) {
    this.parkingService.searchByLocation(location).subscribe(
      (data: Availability[]) => {
        this.sharedService.setParkingData(data);
        this.router.navigate(['/ParkingAvailable']);
      },
      (error) => {}
    );
  }
}
