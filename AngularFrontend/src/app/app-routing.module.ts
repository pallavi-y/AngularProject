import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {Routes} from '@angular/router';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { RegistrationPageComponent } from './components/registration-page/registration-page.component';
import { RouterModule } from '@angular/router';
import { AddDriverFormComponent } from './components/add-driver-form/add-driver-form.component';

const  routes: Routes = [
  {path : '', component: LoginPageComponent},
 { path : '/register', component: RegistrationPageComponent},
 {path: '/add-driver',component: AddDriverFormComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class AppRoutingModule { }
export const RouteComponents=[ RegistrationPageComponent,LoginPageComponent]
