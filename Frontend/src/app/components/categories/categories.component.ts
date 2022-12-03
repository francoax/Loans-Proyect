import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/category';
import { CategoriesService } from 'src/app/services/Categories/categories.service';
import { NotificationService } from 'src/app/services/Notifications/notification.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  constructor(
    private service : CategoriesService,
    private router : Router,
    private notification : NotificationService) { }

  ngOnInit(): void {
    this.getAll();
  }

  displayedColumns: string[] = ['id', 'description'];
  dataSource : MatTableDataSource<Category> = new MatTableDataSource();
  
  getAll() {
  this.service.getAll().subscribe(data => {
    this.dataSource = new MatTableDataSource(data);
  });
  }

  generate() {
    this.service.createCategories().subscribe(() => {
      this.router.navigate(['/categories']);
    });
  }

}
