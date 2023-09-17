import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class ReservedModule {}

export interface ReservedModel {
  rpid: string;
  email: string;
  phoneNo: string;
  slot: string;
  vehicleNo: string;
  identifications: string;
  category: string;
  name: string;
  address: string;
}
