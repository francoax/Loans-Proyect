import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Person } from 'src/app/models/person';
import { NotificationService } from 'src/app/services/Notifications/notification.service';
import { PeopleService } from 'src/app/services/People/people.service';

@Component({
  selector: 'app-create-person',
  templateUrl: './create-person.component.html',
  styleUrls: ['./create-person.component.css']
})
export class CreatePersonComponent implements OnInit {

  constructor(private service : PeopleService, private fb : FormBuilder, private notification : NotificationService, private router : Router) { }
  
  hide = true;

  form! : FormGroup;

  ngOnInit(): void {
    this.form = this.fb.group({
      name : ['', Validators.required],
      phoneNumber : ['', Validators.required],
      email : ['', Validators.required]
    })
  }

  get formCreate() {return this.form.controls;}

  OnSubmit(person : Person) : void {
    if(!this.form.valid){
      this.form.markAllAsTouched();
      this.notification.showMessage("El formulario no es valido");
      return;
    }
    this.service.create(person).subscribe({
      next : (response : any) => {
        this.notification.showMessage("Person creada con exito.");
        this.router.navigate(['/people/list']);
      }
    })

  }

}
