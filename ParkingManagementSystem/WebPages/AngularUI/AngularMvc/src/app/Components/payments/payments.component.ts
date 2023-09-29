import { Component } from '@angular/core';
import { Rtransferdata } from 'src/app/Models/reserved/reserved.module';
import { PaymentdetailsService } from 'src/app/Services/Payments/paymentdetails.service';
import { SharedService } from 'src/app/Services/shared/shared.service';
import { FormsModule } from '@angular/forms';
import { Route, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { ActivatedRoute } from '@angular/router';
import { AuthenticationsService } from 'src/app/Services/Login/authentications.service';

interface PaymentData {
  paymentID: number;
  userID: string;
  amount: number;
  // paymentDate: Date;
  rpid: string;
}

@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.css'],
})
export class PaymentsComponent {
  constructor(
    private sharedService: SharedService,
    private paymentService: PaymentdetailsService,
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthenticationsService
  ) {}

  rTransferData: Rtransferdata | undefined;
  paymentData: PaymentData | undefined;
  paymentSuccessful: boolean = false;

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      const amount = +params['amount']; // "+" is used to convert string to number
      const rpid = params['rpid'];
      this.paymentData = {
        paymentID: 0,
        userID: this.authService.getEmailFromToken(),
        amount: amount,
        rpid: rpid,
      };
    });
  }

  makePayment() {
    if (this.paymentData) {
      this.paymentService.SavePaymentdetails(this.paymentData).subscribe(
        (response) => {
          console.log('Payment successful:', response);
          this.paymentSuccessful = true;
          this.showNotification('Payment Successfully! Done', 'success');
          this.router.navigate(['/Avalability']);
        },
        (error) => {
          this.showNotification('Payment falied!', 'failure');
        }
      );
    } else {
      this.showNotification('Something went wrong!', 'failure');
    }
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
