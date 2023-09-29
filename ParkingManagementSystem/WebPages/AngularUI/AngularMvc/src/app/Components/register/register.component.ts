import { Component } from '@angular/core';
import { AuthenticationsService } from 'src/app/Services/Login/authentications.service';
import { RegisterModule } from 'src/app/Models/register/register.module';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'; // Import Validators and FormBuilder

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  signupDto: RegisterModule = new RegisterModule();
  signupForm: FormGroup;

  constructor(
    private authService: AuthenticationsService,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.signupForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      name: ['', Validators.required],
      phoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
      password: ['', Validators.required],
      role: ['user', Validators.required],
    });
  }

  signup() {
    if (this.signupForm.valid) {
      this.signupDto = this.signupForm.value;
      this.authService.register(this.signupDto).subscribe(
        (response: any) => {
          this.router.navigate(['/Availability']);
          this.showNotification('Registration Successfully', 'success');
        },
        (error: any) => {
          this.showNotification('You have already register!', 'failure');
        }
      );
    } else {
      this.showNotification(
        'Please fill out all required fields correctly',
        'failure'
      );
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
