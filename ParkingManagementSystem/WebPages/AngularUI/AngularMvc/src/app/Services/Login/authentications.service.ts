import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginModule } from 'src/app/Models/login/login.module';
import { RegisterModule } from 'src/app/Models/register/register.module';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { JwtauthModule } from 'src/app/Models/jwtauth/jwtauth.module';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationsService {
  registerUrl = 'auth/register';
  loginUrl = 'auth/login';

  constructor(private http: HttpClient) {}

  public register(user: RegisterModule): Observable<JwtauthModule> {
    return this.http.post<JwtauthModule>(
      `${environment.apiUrl}/${this.registerUrl}`,
      user
    );
  }

  public login(user: LoginModule): Observable<JwtauthModule> {
    return this.http.post<JwtauthModule>(
      `${environment.apiUrl}/${this.loginUrl}`,
      user
    );
  }

  public isLoggedIn(): boolean {
    // Check if the JWT token is stored in localStorage
    const jwtToken = localStorage.getItem('jwtToken');
    return !!jwtToken; // Returns true if jwtToken is not null or undefined
  }

  public logout(): void {
    localStorage.removeItem('jwtToken');
  }
}
