//appmodule.ts
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import { AvailabilityComponent } from './Components/availability/availability.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { ParkingAvailableComponent } from './Components/parking-available/parking-available.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { ReserveParkingComponent } from './Components/reserve-parking/reserve-parking/reserve-parking.component';
import { UserComponentComponent } from './Components/user-component/user-component.component';
import { AdminComponent } from './Components/admin/admin.component';


@NgModule({
  declarations: [
    AppComponent,
    AvailabilityComponent,
    ParkingAvailableComponent,
    LoginComponent,
    RegisterComponent,
    ReserveParkingComponent,
    UserComponentComponent,
    AdminComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    BrowserAnimationsModule,
    FormsModule,
    DatePipe,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
