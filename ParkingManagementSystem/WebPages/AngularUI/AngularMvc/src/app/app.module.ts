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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule, DatePipe } from '@angular/common';
import { ParkingAvailableComponent } from './Components/parking-available/parking-available.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { ReservedparkingComponent } from './Components/reservedparking/reservedparking.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { UserProfileComponent } from './Components/user-profile/user-profile.component';
import { AdwinloginComponent } from './Components/adwinlogin/adwinlogin.component';
import { AdminDashboardComponent } from './Components/admin-dashboard/admin-dashboard.component';
import { DataTablesModule } from 'angular-datatables';

@NgModule({
  declarations: [
    AppComponent,
    AvailabilityComponent,
    ParkingAvailableComponent,
    LoginComponent,
    RegisterComponent,
    ReservedparkingComponent,
    LogoutComponent,
    UserProfileComponent,
    AdwinloginComponent,
    AdminDashboardComponent,
  ],
  imports: [
    ReactiveFormsModule,
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
    CommonModule,
    MatSnackBarModule,
    DataTablesModule,
  ],

  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
