// AvailabilityInterceptor.ts
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationsService } from '../Services/Login/authentications.service';

@Injectable()
export class AvailabilityInterceptor implements HttpInterceptor {
  constructor(private authService: AuthenticationsService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    if (this.authService.isLoggedIn()) {
      const jwtToken = localStorage.getItem('jwtToken');
      if (jwtToken) {
        // Clone the request and add the JWT token to the headers
        const clonedRequest = request.clone({
          setHeaders: {
            Authorization: `Bearer ${jwtToken}`,
          },
        });
        return next.handle(clonedRequest);
      }
    }
    // If not authenticated or no token, continue without modification
    return next.handle(request);
  }
}
