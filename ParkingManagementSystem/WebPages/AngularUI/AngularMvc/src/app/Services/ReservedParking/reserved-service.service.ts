import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ReservedServiceService {
  rUrl = 'ReservedParking';
  slotUrl = 'slots';

  constructor(private http: HttpClient) {}
  createReservedParking(data: any) {
    return this.http.post(`${environment.reservedUrl}/${this.rUrl}`, data);
  }
  updateParkingSlots(slotId: string, slotsData: any): Observable<any> {
    const url = `${environment.slotsurl}/${this.slotUrl}/${slotId}`;
    return this.http.put(url, slotsData);
  }
}
