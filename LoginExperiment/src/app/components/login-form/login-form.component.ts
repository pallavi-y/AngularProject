import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { EmployeeService } from 'src/app/service/employee.service';
import { DriverService } from 'src/app/service/driver.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css'],
})
export class LoginFormComponent implements OnInit {
  constructor(private empService: EmployeeService, private driverService:DriverService,private router: Router) {}
  Puid:string='';
  Verified:boolean=false;
  PickUpStatus:boolean=false;
  DropStatus:boolean=false;
  Name:string='';
  Email:string='';

  ngOnInit(): void {}
  form = {
    email: '',
    password: '',
  };
  radiovalue: string = '';

  onSubmit(): void {
    let obj = {
      Email: this.form.email,
      Password: this.form.password,
    };

   
    // this.router.navigate(['/adminpage']);

    if (this.radiovalue == '1') {
      if (
        this.form.email == 'transadmin@eurofins.com' &&
        this.form.password == 'Transadmin@123'
      ) {
        
        this.router.navigate(['/employee-list']);
      } else {
        alert('Invalid Credentials!!!\nEnter Correct Credentials!!!');
        this.router.navigate(['/']);
      }
    } 
    else if (this.radiovalue == '2') {

      //sending login Details for employee
      this.empService.SubmitEmpLogin(obj).subscribe((data) => {
        console.log(data.puid);
        console.log(data.verified);
        console.log(data.isDrop);
        console.log(data.isPickUp);
        if(data.verified==true)
        {
          this.Verified=data.verified;
          this.Puid=data.puid;
          this.DropStatus=data.isDrop;
          this.PickUpStatus=data.isPickUp;
        }
        if(this.Verified==true)
       {
          if (this.PickUpStatus|| this.DropStatus) {
            this.router.navigate(["/emp-page-cab-detail", { 'Puid': this.Puid}]);
          } 
          else {
            this.router.navigate(["/Employeeregister", { 'Puid': this.Puid }]);
          }
          
        } 
        else {
          alert('Please Enter Correct Credentials');
        }
        
      });
      console.log(JSON.stringify(this.form, null, 2));
     // this.router.navigate(['/Employeeregister']);
    } 
    else if (this.radiovalue == '3') {
      this.driverService.SubmitDriverLogin(obj).subscribe((data) => {
        console.log(data.name);
        console.log(data.verified);
        console.log(data.email);
        
        if(data.verified==true)
        {
          this.Verified=data.verified;
          this.Name=data.name;
          this.Email=data.email;
          
        }
        if(this.Verified==true)
        {
          this.router.navigate(['/driver-page', { 'Email': this.Email, 'Name':this.Name }]);
          
        }
        else
        {
          alert("Please Enter Correct Credentials");
        }
        
      });
      
    } 
    else {
      alert('Please Select Radio Button');
    }

    console.log(JSON.stringify(this.form, null, 2));
  }

  SignUp(form: NgForm): void {
    this.router.navigate(['/verifysignup']);
  }
  
  /** 
    formsignup= {
      email : ''
    }
      OnSubmitSignUp(formsignup: NgForm): void {
        console.log(JSON.stringify(this.formsignup, null, 2));
        this.router.navigate(['/registerform']);
      }
      */
}
