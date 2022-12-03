import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { NotificationService } from 'src/app/services/Notifications/notification.service';
import { UserService } from 'src/app/services/User/user.service';
import { MyErrorStateMatcher } from '../login/login.component';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  userForm! : FormGroup;

  constructor(private formBuilder : FormBuilder, private router : Router, private service : UserService, private notification : NotificationService) { 

    this.userForm = this.formBuilder.group({
      username : ['', [Validators.required, Validators.minLength(4)]],
      password : ['', [Validators.required, Validators.minLength(4)]]
    })

  }

  matcher = new MyErrorStateMatcher();
  

  ngOnInit(): void {

  }

  OnSubmit(user : User) : void {
    if(!this.userForm.valid){
      this.userForm.markAllAsTouched();
      this.notification.showMessage("El formulario no es valido");
      return;
    }
    this.service.signup(user).subscribe({
      next : (response : any) => {
        this.notification.showMessage("Registro completado con exito. Ya puedes iniciar sesion.");
        this.router.navigate(['/people/list']);
      }
    })
  }

  private warnMessages : {type : string, msg : string}[] = [
    {type : 'required', msg : 'is required'},
    {type : 'minlength', msg : 'must have more than 4 letters'}
  ]

  errorMsg(campo : string) : string | null {
    let inputError = this.userForm.get(campo)?.errors;
    for (let e of this.warnMessages){
      if(inputError?.[e.type]) return e.msg
    }
    return null;
  }

  requireWarn(campo : string) : boolean {
    let input = this.userForm.get(campo);
    if(!input) return false;

    return input.invalid && !input.untouched;
  }

  RedirectToLogin() : void{
    this.router.navigate(['/login'])
  }
}
