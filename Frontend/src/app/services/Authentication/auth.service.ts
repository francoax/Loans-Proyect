import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/models/user';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private currentUserSubject : BehaviorSubject<User | null>;
  public currentUser : Observable<User | null>;


  constructor(private http : HttpClient, private router : Router) { 

    this.currentUserSubject = new BehaviorSubject(JSON.parse(localStorage.getItem("currentUser")!));
    this.currentUser = this.currentUserSubject.asObservable();

  }

  public get currentUserValue() : User | null {
    return this.currentUserSubject.value;
  }

  login(username : string, password : string){
    return this.http.post<any>(`${environment.api}/auth/login`, {username, password})
      .pipe(map(user => {
        localStorage.setItem('currentUser', JSON.stringify(user))
        this.currentUserSubject.next(user);
        return user;
      }))
  }

  logOut() : void {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
    this.router.navigate(['/']);
  }
}
