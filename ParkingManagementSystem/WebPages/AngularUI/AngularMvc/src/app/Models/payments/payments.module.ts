import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class PaymentsModule {}
export interface PaymentData {
  userID: string;
  amount: number;
  paymentDate: Date;
  rpid: string;
}
