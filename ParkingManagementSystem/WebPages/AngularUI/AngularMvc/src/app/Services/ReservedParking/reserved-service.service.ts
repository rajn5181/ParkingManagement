import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ReservedServiceService {
  rUrl = 'ReservedParking';

  constructor(private http: HttpClient) {}
  createReservedParking(data: any) {
    return this.http.post(`${environment.reservedUrl}/${this.rUrl}`, data);
  }
}
