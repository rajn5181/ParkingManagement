import { Component, OnInit } from '@angular/core';
import { AuthenticationsService } from 'src/app/Services/Login/authentications.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css'],
})
export class LogoutComponent implements OnInit {
  constructor(
    private authService: AuthenticationsService,
    private router: Router
  ) {}

  ngOnInit() {
    this.logout();
  }

  logout() {
    this.authService.logout();

    setTimeout(() => {
      this.router.navigate(['/logout']);
    }, 2000);
  }
}
