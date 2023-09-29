import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AdminParkinslotService {
  private AdminParking = 'cpa';

  constructor(private http: HttpClient) {}

  createReservedParking(data: any) {
    return this.http.post(`${environment.slotsurl}/${this.AdminParking}`, data);
  }

  getParkingSlotData(id: string) {
    return this.http.get(`${environment.slotsurl}/${this.AdminParking}/${id}`);
  }
}
