import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from 'src/app/models/person';
import { NotificationService } from 'src/app/services/Notifications/notification.service';
import { PeopleService } from 'src/app/services/People/people.service';

@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrls: ['./edit-person.component.css']
})
export class EditPersonComponent implements OnInit {

  constructor(private service : PeopleService, private fb : FormBuilder, private notification : NotificationService, private router : Router, private route : ActivatedRoute) { }
  
  hide = true;
  personToEdit! : Person;
  form! : FormGroup;
  id! : number;

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.getPerson(this.id);
    this.form = this.fb.group({
      name : ['', Validators.required],
      phoneNumber : ['', Validators.required],
      email : ['', Validators.required],
    });
  }

  getPerson(id : number) {
    this.service.getOne(id).subscribe(data => {
      this.personToEdit = data;
    });
  }

  get f() {return this.form.controls;}

  OnSubmit(person : Person) : void {
    person.id = this.id;
    if(!this.form.valid){
      this.form.markAllAsTouched();
      this.notification.showMessage("El formulario no es valido");
      return;
    }
    this.service.update(person).subscribe({
      next : (response : any) => {
        this.notification.showMessage("Persona editada con exito.");
        this.router.navigate(['/people/list']);
      }
    })

  }

}
