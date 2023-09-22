import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ParkingavailableService {
  // private apiUrl = 'http://localhost:6001/api/cpa/by-date';
  private apiUrl = 'https://localhost:5001/api/cpa/by-date';

  private locationiUrl = 'cpa/search-by-location';
  constructor(private http: HttpClient) {}

  getDataByDate(date: string): Observable<any> {
    const url = `${this.apiUrl}/${date}`;
    return this.http.get(url);
  }

  searchByLocation(location: string): Observable<any> {
    const url = `${environment.locations}/${this.locationiUrl}?location=${location}`;
    return this.http.get(url);
  }
}
