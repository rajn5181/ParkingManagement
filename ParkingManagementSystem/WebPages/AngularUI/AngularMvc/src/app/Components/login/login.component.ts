import { Component } from '@angular/core';
import { AuthenticationsService } from 'src/app/Services/Login/authentications.service';
import { LoginModule } from 'src/app/Models/login/login.module';
import { RegisterModule } from 'src/app/Models/register/register.module';
import { JwtauthModule } from 'src/app/Models/jwtauth/jwtauth.module';
import { Route, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm: FormGroup | undefined;
  loginDto = new LoginModule();
  registerDto = new RegisterModule();
  jwtDto = new JwtauthModule();

  constructor(
    private authservice: AuthenticationsService,
    private router: Router
  ) {}
  CheckLoginStatus() {
    const jwtToken = localStorage.getItem('jwtToken');
    if (jwtToken) {
      const decodedToken: any = jwt_decode(jwtToken);
      console.log(decodedToken);
      if (decodedToken.nameid === 'user') {
        return this.router.navigate(['/Avalability']);
      } else {
        return this.router.navigate(['/admindashboard']);
      }
    } else {
      return this.Login(this.loginDto);
    }
  }
  Login(loginDto: LoginModule) {
    // this.CheckLoginStatus();
    this.authservice.login(loginDto).subscribe(
      (response) => {
        console.log(response);
        if (response.isSuccess && response.result && response.result.tokens) {
          const jwtToken = response.result.tokens;
          localStorage.setItem('jwtToken', jwtToken);
          this.router.navigate(['/Avalability']);
          this.showNotification('Login Successfully', 'success');
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
function jwt_decode(jwtToken: string): any {
  throw new Error('Function not implemented.');
}
