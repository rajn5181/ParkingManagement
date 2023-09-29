import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  private parkingData: any;
  private reservedData: any;

  constructor() {}
  setParkingData(data: any) {
    this.parkingData = data;
  }

  getParkingData() {
    return this.parkingData;
  }
  setReservedData(data: any) {
    this.reservedData = data;
  }
  getReservedData() {
    return this.reservedData;
  }
}
