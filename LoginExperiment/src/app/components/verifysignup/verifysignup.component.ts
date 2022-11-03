import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { EmployeeService } from 'src/app/service/employee.service';

@Component({
  selector: 'app-verifysignup',
  templateUrl: './verifysignup.component.html',
  styleUrls: ['./verifysignup.component.css']
})
export class VerifysignupComponent implements OnInit {

  Exists:boolean=false;
  constructor(private service: EmployeeService,private router: Router) { }

  ngOnInit(): void {
  }

  form = {
    email : ''
  }

  onSubmit(): void {
    console.log(JSON.stringify(this.form, null, 2));
    this.service.getemail(this.form.email).subscribe(data=>{

      this.Exists=data.exists;
      console.log(this.Exists);
      if(this.Exists==true)
    {
      this.router.navigate(["/registerform", { 'email': this.form.email }]);
    }
    else{
      alert("Please Enter Company registered Email");
    }

    });
   
  }
      
    }


