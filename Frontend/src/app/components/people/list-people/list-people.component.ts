import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Person } from 'src/app/models/person';
import { PeopleService } from 'src/app/services/People/people.service';

@Component({
  selector: 'app-list-people',
  templateUrl: './list-people.component.html',
  styleUrls: ['./list-people.component.css']
})
export class ListPeopleComponent implements OnInit {

  constructor(private service : PeopleService) { }

  ngOnInit(): void {
    this.generateList();
  }

  displayedColumns: string[] = ['id', 'name', 'email', 'phoneNumber', 'actions'];
  dataSource : MatTableDataSource<Person> = new MatTableDataSource();
  
  generateList() {
  this.service.getAll().subscribe(data => {
    this.dataSource = new MatTableDataSource(data);
  });
  }
}
