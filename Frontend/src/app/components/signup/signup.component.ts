import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MyErrorStateMatcher } from '../login/login.component';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  userForm! : FormGroup;

  constructor(private formBuilder : FormBuilder, private router : Router) { 

    this.userForm = this.formBuilder.group({
      username : ['', [Validators.required, Validators.minLength(4)]],
      password : ['', [Validators.required, Validators.minLength(5)]]
    })

  }

  matcher = new MyErrorStateMatcher();
  

  ngOnInit(): void {

  }

  OnSubmit() : void{

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
