import { Component } from '@angular/core';
import { AuthenticationsService } from 'src/app/Services/Login/authentications.service';
import { LoginModule } from 'src/app/Models/login/login.module';
import { RegisterModule } from 'src/app/Models/register/register.module';
import { JwtauthModule } from 'src/app/Models/jwtauth/jwtauth.module';
import { Route, Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginDto = new LoginModule();
  registerDto = new RegisterModule();
  jwtDto = new JwtauthModule();

  constructor(
    private authservice: AuthenticationsService,
    private router: Router
  ) {}

  Login(loginDto: LoginModule) {
    this.authservice.login(loginDto).subscribe(
      (response) => {
        if (response.isSuccess && response.result && response.result.tokens) {
          // Extract the JWT token from the response
          const jwtToken = response.result.tokens;
          localStorage.setItem('jwtToken', jwtToken);
          this.router.navigate(['/Avalability']);
        } else {
          console.error('Login failed. Response:', response);
        }
      },
      (error) => {
        console.error('Login failed. Error:', error);
      }
    );
  }
}
