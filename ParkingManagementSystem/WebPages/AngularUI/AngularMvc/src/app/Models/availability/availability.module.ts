import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ParkingAvailableComponent } from 'src/app/Components/parking-available/parking-available.component';

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class AvailabilityModule {}

// availability.model.ts
export interface Availability {
  Pid: string;
  Status: boolean;
  Slots: SlotModel[];
  Available: Date;
}

export interface SlotModel {
  Id: string;
  Two: boolean;
  Three: boolean;
  Six: boolean;
  Twelve: boolean;
  Day: boolean;
}
