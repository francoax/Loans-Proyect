import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from 'src/app/models/person';
import { NotificationService } from 'src/app/services/Notifications/notification.service';
import { PeopleService } from 'src/app/services/People/people.service';

@Component({
  selector: 'app-delete-person',
  templateUrl: './delete-person.component.html',
  styleUrls: ['./delete-person.component.css']
})
export class DeletePersonComponent implements OnInit {

  constructor(private service : PeopleService, private route : ActivatedRoute, private router : Router, private notification : NotificationService) { }

  personToDelete! : Person;

  ngOnInit(): void {
    this.service.getOne(Number(this.route.snapshot.paramMap.get('id'))).subscribe(data =>{
      this.personToDelete = data;
    })
  }

  getPerson(id : number) {
    this.service.getOne(id).subscribe(data => {
      this.personToDelete = data;
    });
  }

  delete() {
    this.service.delete(this.personToDelete.id!).subscribe( {
      next : (response : any) => {
        this.notification.showMessage("Persona eliminada con exito.");
        this.router.navigate(['/people/list']);
    }});
  }

}
