import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/Services/shared/shared.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-parking-available',
  templateUrl: './parking-available.component.html',
  styleUrls: ['./parking-available.component.css'],
})
export class ParkingAvailableComponent implements OnInit {
  parkingData: any;
  trueSlots: string[] = [];

  constructor(private sharedService: SharedService, private router: Router) {}

  ngOnInit() {
    this.parkingData = this.sharedService.getParkingData();
    console.log(this.parkingData);
  }
  bookParking(pid: string, selectedSlot: string) {
    this.router.navigate(['/reservedparking'], {
      queryParams: { pid, slot: selectedSlot },
    });
  }
  getSlotKeys(slots: any): string[] {
    const availableKeys: string[] = [];

    slots.forEach((slotObj: any) => {
      Object.keys(slotObj).forEach((key) => {
        if (slotObj[key] == true) {
          availableKeys.push(key);
        }
      });
    });

    return availableKeys;
  }
}
