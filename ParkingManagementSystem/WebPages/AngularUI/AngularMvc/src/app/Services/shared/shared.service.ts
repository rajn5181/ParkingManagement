import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  private parkingData: any; // Change 'any' to the actual data type you're using

  constructor() {}

  // Method to set the parking data
  setParkingData(data: any) {
    this.parkingData = data;
  }

  // Method to get the parking data
  getParkingData() {
    return this.parkingData;
  }
}
