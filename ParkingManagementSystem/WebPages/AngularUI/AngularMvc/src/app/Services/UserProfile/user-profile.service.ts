import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserProfile } from 'src/app/Models/userprofile/userprofile.module';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserProfileService {
  private apiUrl = 'Profile/FetchUserData?userId=';
  private profileUrl = 'Profile/FetchUserProfile?userEmail=';

  constructor(private http: HttpClient) {}

  fetchUserData(userId: string): Observable<UserProfile> {
    const body = { userId: userId };
    const url = `${environment.userProfileUrl}/${this.apiUrl}${userId}`;
    return this.http.get<UserProfile>(url);
  }

  fetchUserProfile(userId: string): Observable<UserProfile> {
    const body = { userId: userId };
    const url = `${environment.userProfileUrl}/${this.profileUrl}${userId}`;
    return this.http.get<UserProfile>(url);
  }
}
