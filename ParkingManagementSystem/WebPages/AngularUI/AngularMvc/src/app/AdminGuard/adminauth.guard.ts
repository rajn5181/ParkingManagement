// authguard.ts
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AdwinserviceService } from '../Services/AdwinLogin/adwinservice.service';

@Injectable({
  providedIn: 'root',
})
export class AdminGauard implements CanActivate {
  constructor(
    private authService: AdwinserviceService,
    private router: Router
  ) {}

  canActivate(): boolean {
    if (this.authService.isLoggedIn()) {
      return true;
    } else {
      this.router.navigate(['']);
      return false;
    }
  }
}
