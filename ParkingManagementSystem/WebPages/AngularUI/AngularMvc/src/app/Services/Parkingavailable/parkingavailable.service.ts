import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ParkingavailableService {
  private apiUrl = 'https://localhost:7119/api/cpa/by-date';

  constructor(private http: HttpClient) {}

  getDataByDate(date: string): Observable<any> {
    const url = `${this.apiUrl}/${date}`;
    return this.http.get(url);
  }
}
