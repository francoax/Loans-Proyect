import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher, ThemePalette} from '@angular/material/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';
import { AuthenticationService } from 'src/app/services/Authentication/auth.service';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formLogin! : FormGroup;
  loading = false;
  submitted = false;
  returnUrl! : string;
  error = '';
  color : ThemePalette = 'primary';
  mode : ProgressSpinnerMode = 'indeterminate';
  value = 50;
  diameter = 50;

  constructor(
    private router: Router, 
    private formBuilder : FormBuilder,
    private route : ActivatedRoute,
    private authenthicationService : AuthenticationService
  ){ 

    if(this.authenthicationService.currentUserValue){
      this.router.navigate(['/home']);
    }

  }

  ngOnInit() {
    this.formLogin = this.formBuilder.group({
      username : ['', [Validators.required]],
      password : ['', [Validators.required]]
    })
  }

  get form() {return this.formLogin.controls;}

  matcher = new MyErrorStateMatcher();

  OnSubmit() {
    this.submitted = true;

    if(this.formLogin.invalid){
      return;
    }

    this.error = '';
    this.loading = true;
    this.authenthicationService.login(this.form['username'].value, this.form['password'].value)
      .pipe(first())
      .subscribe({
          next: () => {
            this.router.navigate(["/home"]);
          },
          error: error => {
            this.error = error;
            this.loading = false;
          }
      }) 
  }

  register() : void {
    this.router.navigate(['/signup'])
  }

  requireWarn(campo : string) : boolean {
    let input = this.formLogin.get(campo);
    if(!input) return false;

    return input.invalid && !input.untouched;
  }
  
  private warnMessages : {type : string, msg : string}[] = [
    {type : 'required', msg : 'is required'},
    {type : 'minlength', msg : 'must have more than 4 letters'}
  ]

  errorMsg(campo : string) : string | null {
    let inputError = this.formLogin.get(campo)?.errors;
    for (let e of this.warnMessages){
      if(inputError?.[e.type]) return e.msg
    }
    return null;
  }
}


