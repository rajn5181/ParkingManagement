import { Component } from '@angular/core';
import { ReservedServiceService } from 'src/app/Services/ReservedParking/reserved-service.service';
import { ReservedModel } from 'src/app/Models/reserved/reserved.module';

@Component({
  selector: 'app-reservedparking',
  templateUrl: './reservedparking.component.html',
  styleUrls: ['./reservedparking.component.css'],
})
export class ReservedparkingComponent {
  formData: ReservedModel = {
    rpid: '',
    email: '',
    phoneNo: '',
    slot: '',
    vehicleNo: '',
    identifications: '',
    category: [],
    name: '',
    address: '',
  };

  constructor(private reservedService: ReservedServiceService) {}

  reserveParking() {
    this.reservedService.createReservedParking(this.formData).subscribe(
      (response) => {
        // Handle success, e.g., show a success message
        console.log('Reservation successful:', response);
      },
      (error) => {
        // Handle error, e.g., show an error message
        console.error('Error reserving parking:', error);
      }
    );
  }
}
