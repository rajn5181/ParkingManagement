import { Component, OnInit } from '@angular/core';
import { AuthenticationsService } from 'src/app/Services/Login/authentications.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

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
    const jwtToken = localStorage.getItem('jwtToken');
    if (!jwtToken) {
      this.showNotification('You have already logged out!', 'failure');
      this.router.navigate(['']);
    } else {
      this.authService.logout();
      setTimeout(() => {
        this.router.navigate(['/logout']);
      }, 2000);
    }
  }
  showNotification(message: string, type: string) {
    Swal.fire({
      icon: type === 'success' ? 'success' : 'error',
      title: message,
      showConfirmButton: false,
      timer: 2000,
    });
  }
}
