import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { AuthenticationService } from 'src/app/services/Authentication/auth.service';
import { NotificationService } from 'src/app/services/Notifications/notification.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private authenticationService : AuthenticationService,
    private notificationService : NotificationService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {
      if(err instanceof HttpErrorResponse) {
        switch(err.status){
          case 400 : {
            this.notificationService.showMessage(err.error)
            break;
          }
          case 401: {            
            this.notificationService.showMessage(err.error)
            this.authenticationService.logOut();
            break;
          }
          case 403: {            
            this.notificationService.showMessage(err.error)
            this.authenticationService.logOut();
            break;
          }
          case 404: {            
            this.notificationService.showMessage(err.error)
            break;
          }
          case 500: {            
            this.notificationService.showMessage("Ups... Parece que hubo un error. Intente mas tarde.")
            this.authenticationService.logOut();
            break;
          }
          default: {
            this.notificationService.showMessage("Hmmm esto no deberia pasar... Intente mas tarde")
            this.authenticationService.logOut();
            break;
          }
        }
        
      }
      const error = err.error.messagge || err.statusText;
      return throwError(() => error);
    }))
  }
}
