import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/Services/shared/shared.service';

@Component({
  selector: 'app-parking-available',
  templateUrl: './parking-available.component.html',
  styleUrls: ['./parking-available.component.css'],
})
export class ParkingAvailableComponent implements OnInit {
  parkingData: any;
  trueSlots: string[] = []; // Create a property to store the true slots

  constructor(private sharedService: SharedService) {}

  ngOnInit() {
    this.parkingData = this.sharedService.getParkingData();
    console.log(this.parkingData);

    this.populateTrueSlots();
  }

  private populateTrueSlots() {
    if (this.parkingData && this.parkingData.length > 0) {
      const firstItem = this.parkingData[0];

      if (
        firstItem.slots &&
        Array.isArray(firstItem.slots) &&
        firstItem.slots.length > 0
      ) {
        const slotsObj = firstItem.slots[0];

        if (typeof slotsObj === 'object') {
          this.trueSlots = Object.keys(slotsObj).filter(
            (key) => key !== 'id' && slotsObj[key] === true
          );
          console.log(this.trueSlots);
        }
      }
    }
  }
}
