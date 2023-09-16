import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ParkingAvailableComponent } from './Components/parking-available/parking-available.component';
import { AvailabilityComponent } from './Components/availability/availability.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { AuthGuard } from './Guard/authguard.guard';
import { ReservedparkingComponent } from './Components/reservedparking/reservedparking.component';

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
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
