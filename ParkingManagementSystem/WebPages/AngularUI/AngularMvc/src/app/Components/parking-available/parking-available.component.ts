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
  dtoptions: DataTables.Settings = {};
  constructor(private sharedService: SharedService, private router: Router) {}

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
      if (slotObj.two < slotObj.limit_Block1) {
        availableKeys.push('Block1');
      }
      if (slotObj.three < slotObj.limit_Block2) {
        availableKeys.push('Block2');
      }
      if (slotObj.six < slotObj.limit_Block3) {
        availableKeys.push('Block3');
      }
      if (slotObj.twelve < slotObj.limit_Block4) {
        availableKeys.push('Block4');
      }
      if (slotObj.day < slotObj.limit_Block5) {
        availableKeys.push('Block5');
      }
    });
    return availableKeys;
  }
}
