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
  category: Category[];
  name: string;
  address: string;
}

export interface Category {
  tid: number;
  categories: string;
}
