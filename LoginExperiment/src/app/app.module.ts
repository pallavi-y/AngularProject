import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { RegisterformComponent } from './components/registerform/registerform.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AdminpageComponent } from './components/adminpage/adminpage.component';
import { AddcabComponent } from './components/addcab/addcab.component';
import { FooterComponent } from './footer/footer.component';
import { AssigncabtodriverComponent } from './components/assigncabtodriver/assigncabtodriver.component';
import { StartComponent } from './components/start/start.component';
import { MatchPasswordDirective } from './directives/match-password.directive';
import { VerifysignupComponent } from './components/verifysignup/verifysignup.component';
import { EmployeeFormComponent } from './components/employee-form/employee-form.component';
import { AddDriverFormComponent } from './components/add-driver-form/add-driver-form.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { DriverPageComponent } from './components/driver-page/driver-page.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import {HttpClientModule} from '@angular/common/http';
import { GetDetailsService } from './get-details.service';
import { ReactiveFormsModule } from '@angular/forms';
import { DisplaycabanddriverComponent } from './components/displaycabanddriver/displaycabanddriver.component';
import { EmployeePageCabDetailsComponent } from './components/employee-page-cab-details/employee-page-cab-details.component';
import { DriverCarInfoComponent } from './components/driver-car-info/driver-car-info.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LoginFormComponent,
    RegisterformComponent,
    
    AdminpageComponent,
         AddcabComponent,
         FooterComponent,
         AssigncabtodriverComponent,
         StartComponent,
         MatchPasswordDirective,
         VerifysignupComponent,

         LoginPageComponent,
    EmployeeFormComponent,
    AddDriverFormComponent,
    FooterComponent,
    EmployeeListComponent,
         DriverPageComponent,
         DisplaycabanddriverComponent,
         EmployeePageCabDetailsComponent,
         DriverCarInfoComponent
     
       

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,


    RouterModule.forRoot([
      
      {path : '',component: StartComponent},
      {path : 'registerform',component: RegisterformComponent},
      {path : 'addcab',component: AddcabComponent},
      {path : 'adminpage',component: AdminpageComponent},
      {path : 'assigncabtodriver',component: AssigncabtodriverComponent},
      {path : 'verifysignup',component: VerifysignupComponent},
      {path : 'Employeeregister',component: EmployeeFormComponent},
      {path : 'addDriver',component: AddDriverFormComponent},
      {path : 'employee-list',component: EmployeeListComponent},
      {path : 'driver-page',component: DriverPageComponent},
      {path : 'displaycabanddriver',component: DisplaycabanddriverComponent},
      {path : 'start',component: StartComponent},
      {path : 'emp-page-cab-detail',component: EmployeePageCabDetailsComponent},
      {path : 'my-cab-detail',component: DriverCarInfoComponent },




      

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
