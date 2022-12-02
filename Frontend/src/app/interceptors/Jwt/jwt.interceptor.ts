import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from 'src/app/services/Authentication/auth.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private authenticationSerive : AuthenticationService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    let currentUser = this.authenticationSerive.currentUserValue;
    if(currentUser && currentUser.token){
      request = request.clone({
        setHeaders : {
          Authorization : `Bearer ${currentUser.token}`
        }
      })
    }
    return next.handle(request);
  }
}
