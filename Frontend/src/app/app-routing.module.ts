import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { CreatePersonComponent } from './components/people/create-person/create-person.component';
import { DeletePersonComponent } from './components/people/delete-person/delete-person.component';
import { ListPeopleComponent } from './components/people/list-people/list-people.component';
import { PeopleComponent } from './components/people/people.component';
import { SignupComponent } from './components/signup/signup.component';
import { AuthGuard } from './guards/Auth/auth.guard';

const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
  { path: 'people', component: PeopleComponent, canActivate: [AuthGuard],
    children: [
      {path: 'create', component: CreatePersonComponent},
      {path: 'list', component: ListPeopleComponent},
      {path: 'delete/:id', component: DeletePersonComponent},
      {path: 'edit/:id', component: DeletePersonComponent}]},
  { path: 'login', component: LoginComponent},
  { path : 'signup', component: SignupComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
