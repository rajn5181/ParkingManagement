import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ParkingAvailableComponent } from './Components/parking-available/parking-available.component';
import { AvailabilityComponent } from './Components/availability/availability.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { AuthGuard } from './Guard/authguard.guard';
import { ReservedparkingComponent } from './Components/reservedparking/reservedparking.component';
import { UserdashboardComponent } from './Components/userdashboard/userdashboard.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { PaymentsComponent } from './Components/payments/payments.component';

const routes: Routes = [
  {
    path: 'Avalability',
    component: AvailabilityComponent,
  },
  {
    path: 'ParkingAvailable',
    component: ParkingAvailableComponent,
  },
  {
    path: '',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'reservedparking',
    component: ReservedparkingComponent,
  },
  {
    path: 'dashboard',
    component: UserdashboardComponent,
  },
  {
    path: 'logout',
    component: LogoutComponent,
  },
  {
    path: 'Payment',
    component: PaymentsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
