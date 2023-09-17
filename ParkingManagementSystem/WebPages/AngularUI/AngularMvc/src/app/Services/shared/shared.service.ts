import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  private parkingData: any;

  constructor() {}
  setParkingData(data: any) {
    this.parkingData = data;
  }

  getParkingData() {
    return this.parkingData;
  }
}
