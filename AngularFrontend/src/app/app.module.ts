import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { RegistrationPageComponent } from './components/registration-page/registration-page.component';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { EmployeeFormComponent } from './components/employee-form/employee-form.component';
import { AddDriverFormComponent } from './components/add-driver-form/add-driver-form.component';
import {HttpClientModule} from '@angular/common/http';
import { GetDetailsService } from './get-details.service';

import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { DriverPageComponent } from './components/driver-page/driver-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FooterComponent } from './components/footer/footer.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    RegistrationPageComponent,
    EmployeeFormComponent,
    AddDriverFormComponent,
    FooterComponent,
    EmployeeListComponent,
         DriverPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path : 'register',component: EmployeeFormComponent},
      {path : 'add-user',component: AddDriverFormComponent},
      {path : 'employee-list',component: EmployeeListComponent},
      {path : 'driver-page',component: DriverPageComponent},
      {path : '',component: LoginPageComponent}

    ])
  ],
  providers: [GetDetailsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
