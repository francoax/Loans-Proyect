import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/Authentication/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private authenticationService : AuthenticationService) { }

  showComponent! : boolean;

  ngOnInit(): void {
  }

  logout() {
    this.authenticationService.logOut();
  }

}
