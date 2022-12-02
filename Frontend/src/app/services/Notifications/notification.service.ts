import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private snakBar : MatSnackBar) { }

  showMessage(message : string){
    this.snakBar.open(message, '',{
      horizontalPosition: "center",
      verticalPosition: 'top',
      duration: 3000
    })
  }
}
