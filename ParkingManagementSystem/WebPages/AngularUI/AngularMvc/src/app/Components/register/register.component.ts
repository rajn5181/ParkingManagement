import { Component } from '@angular/core';
import { AuthenticationsService } from 'src/app/Services/Login/authentications.service';
import { RegisterModule } from 'src/app/Models/register/register.module';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  signupDto: RegisterModule = new RegisterModule();

  constructor(private authService: AuthenticationsService) {}

  signup() {
    // Call the register method from the service
    this.authService.register(this.signupDto).subscribe(
      (response: any) => {
        // Registration successful, handle the response as needed
        console.log('Registration successful:', response);
      },
      (error: any) => {
        // Registration failed, handle the error
        console.error('Registration failed:', error);
      }
    );
  }
}
