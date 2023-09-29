import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class UserprofileModule {}
export interface UserProfile {
  length: number;
  bookingDetails: any[];
  name: string;
  email: string;
  address: string;
  identifications: string;
  phoneNo: string;
  rpid: string;
  slot: string;
  PKID: string;
  vehicleNo: string;
  paymentDate: string;
  receiptNumber: string;
  amount: number;
}
export interface profiledata {
  name: string;
  address: string;
  phoneNo: string;
}
