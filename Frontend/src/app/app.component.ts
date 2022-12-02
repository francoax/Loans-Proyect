import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './models/user';
import { AuthenticationService } from './services/Authentication/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frontend';
  currentUser! : User | null;

  constructor(
    private router : Router,
    private authenticationService : AuthenticationService){  
      this.authenticationService.currentUser.subscribe(u => this.currentUser = u);
    }

  logOut(){
    this.authenticationService.logOut();
    this.router.navigate(['/']);
  }


}
