import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PaymentdetailsService {
  paymenturl = 'Payment';

  constructor(private http: HttpClient) {}

  SavePaymentdetails(data: any) {
    return this.http.post(`${environment.paymentur}/${this.paymenturl}`, data);
  }
  DeletePaymentById(id: string): Observable<any> {
    const url = `${environment.paymentur}/${this.paymenturl}/${id}`;
    return this.http.delete(url);
  }
}
