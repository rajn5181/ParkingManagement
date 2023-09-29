import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AdwinModelRegisterModule } from 'src/app/Models/adwin-model-register/adwin-model-register.module';
import { AdwinModelModule } from 'src/app/Models/adwin-model/adwin-model.module';
import { JwtauthModule } from 'src/app/Models/jwtauth/jwtauth.module';
import { AdwinserviceService } from 'src/app/Services/AdwinLogin/adwinservice.service';
import { UserProfileService } from 'src/app/Services/UserProfile/user-profile.service';
import Swal from 'sweetalert2/dist/sweetalert2.js';

@Component({
  selector: 'app-adwinlogin',
  templateUrl: './adwinlogin.component.html',
  styleUrls: ['./adwinlogin.component.css'],
})
export class AdwinloginComponent {
  loginDto = new AdwinModelModule();
  registerDto = new AdwinModelRegisterModule();
  jwtDto = new JwtauthModule();
  email: string = '';

  constructor(
    private authservice: AdwinserviceService,
    private router: Router
  ) {}

  Login(loginDto: AdwinModelModule) {
    this.authservice.login(loginDto).subscribe(
      (response) => {
        console.log(response);
        const Role = response.result.user.role.toLowerCase();
        console.log(Role);
        if (
          response.isSuccess &&
          response.result &&
          response.result.tokens &&
          Role == 'admin'
        ) {
          const jwtToken = response.result.tokens;
          localStorage.setItem('jwtToken', jwtToken);
          this.showNotification('Login Successfully', 'success');
          this.router.navigate(['/admindashboard']);
        } else {
          this.showNotification('Login failed', 'failure');
        }
      },
      (error) => {
        this.showNotification('Login failed', 'failure');
      }
    );
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
