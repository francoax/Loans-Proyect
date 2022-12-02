import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from 'src/app/models/person';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  constructor(private http : HttpClient) { }

  create(person : Person) : Observable<Person> {
    return this.http.post<Person>(`${environment.api}/people`, person);
  }

  update(person: Person): Observable<Person> {
    return this.http.put<Person>(`${environment.api}/people/${person.id}`, person);
  }

  delete(id : number) : void {
    this.http.delete(`${environment.api}/people/${id}`);
  }

  getAll() : Observable<Person[]> {
    return this.http.get<Person[]>(`${environment.api}/people`)
  }


}
