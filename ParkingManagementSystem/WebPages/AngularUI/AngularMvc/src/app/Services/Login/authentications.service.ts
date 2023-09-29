import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginModule } from 'src/app/Models/login/login.module';
import { RegisterModule } from 'src/app/Models/register/register.module';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { JwtauthModule } from 'src/app/Models/jwtauth/jwtauth.module';
import jwt_decode from 'jwt-decode';
@Injectable({
  providedIn: 'root',
})
export class AuthenticationsService {
  registerUrl = 'auth/register';
  loginUrl = 'auth/login';

  constructor(private http: HttpClient) {}
  getEmailFromToken() {
    const jwtToken = localStorage.getItem('jwtToken');

    if (jwtToken) {
      const decodedToken: any = jwt_decode(jwtToken);
      return decodedToken.email;
    }

    return null;
  }

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
    const jwtToken = localStorage.getItem('jwtToken');
    if (jwtToken) {
      const decodedToken: any = jwt_decode(jwtToken);
      console.log(decodedToken); // Check the contents of the decoded token
      if (decodedToken.nameid === 'user') {
        return true;
      }
    }
    return false;
  }

  public logout(): void {
    localStorage.removeItem('jwtToken');
  }
}
