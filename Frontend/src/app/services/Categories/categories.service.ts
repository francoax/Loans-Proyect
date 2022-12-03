import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category } from 'src/app/models/category';


@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  constructor(private http : HttpClient) { }

  categories : Category[] = [
    {
      description : 'Herramientas'
    },
    {
      description : 'Materiales'
    },
    {
      description : 'Tecnologia'
    },
    {
      description : 'Juguetes'
    },
    {
      description : 'Cocina'
    },
    {
      description : 'Muebles'
    },
    {
      description : 'Dinero'
    },
    {
      description : 'Indumentaria'
    }
  ]

  createCategories(): Observable<Category> {

    return this.http.post(`${environment.api}/categories/default`, this.categories);

  }

  getAll() : Observable<Category[]>{

    return this.http.get<Category[]>(`${environment.api}/categories`);

  }

}
