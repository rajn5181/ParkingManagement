import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { JwtauthModule } from 'src/app/Models/jwtauth/jwtauth.module';
import jwt_decode from 'jwt-decode';
import { HttpClient } from '@angular/common/http';
import { AdwinModelModule } from 'src/app/Models/adwin-model/adwin-model.module';
import { AdwinModelRegisterModule } from 'src/app/Models/adwin-model-register/adwin-model-register.module';

@Injectable({
  providedIn: 'root',
})
export class AdwinserviceService {
  adwinloginurl = 'auth/adwin-login';
  adwinregister = 'auth/adwin-register';
  constructor(private http: HttpClient) {}
  getEmailFromToken() {
    const jwtToken = localStorage.getItem('jwtToken');

    if (jwtToken) {
      const decodedToken: any = jwt_decode(jwtToken);

      return decodedToken.email;
    }

    return null;
  }

  public register(user: AdwinModelRegisterModule): Observable<JwtauthModule> {
    return this.http.post<JwtauthModule>(
      `${environment.loginadwin}/${this.adwinregister}`,
      user
    );
  }

  public login(user: AdwinModelModule): Observable<JwtauthModule> {
    return this.http.post<JwtauthModule>(
      `${environment.loginadwin}/${this.adwinloginurl}`,
      user
    );
  }

  public isLoggedIn(): boolean {
    const jwtToken = localStorage.getItem('jwtToken');
    if (jwtToken) {
      const decodedToken: any = jwt_decode(jwtToken);
      console.log(decodedToken); // Check the contents of the decoded token
      if (decodedToken.nameid === 'admin') {
        return true;
      }
    }
    return false;
  }

  public logout(): void {
    localStorage.removeItem('jwtToken');
  }
}
