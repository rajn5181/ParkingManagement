import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ParkingAvailableComponent } from './Components/parking-available/parking-available.component';
import { AvailabilityComponent } from './Components/availability/availability.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { AuthGuard } from './Guard/authguard.guard';
import { ReservedparkingComponent } from './Components/reservedparking/reservedparking.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { PaymentsComponent } from './Components/payments/payments.component';
import { UserProfileComponent } from './Components/user-profile/user-profile.component';
import { AdwinloginComponent } from './Components/adwinlogin/adwinlogin.component';
import { AdminDashboardComponent } from './Components/admin-dashboard/admin-dashboard.component';
import { AdminGauard } from './AdminGuard/adminauth.guard';

const routes: Routes = [
  {
    path: 'Avalability',
    canActivate: [AuthGuard],
    component: AvailabilityComponent,
  },
  {
    path: 'ParkingAvailable',
    canActivate: [AuthGuard],
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
    canActivate: [AuthGuard],
    component: ReservedparkingComponent,
  },
  {
    path: 'logout',
    component: LogoutComponent,
  },
  {
    path: 'Payment',
    canActivate: [AuthGuard],
    component: PaymentsComponent,
  },
  {
    path: 'userProfile',
    canActivate: [AuthGuard],
    component: UserProfileComponent,
  },
  {
    path: 'adminlogin',
    component: AdwinloginComponent,
  },
  {
    path: 'admindashboard',
    canActivate: [AdminGauard],
    component: AdminDashboardComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
