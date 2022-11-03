import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { EmployeeService } from 'src/app/service/employee.service';
import { Empdetails } from 'src/app/models/empdetails';
@Component({
  selector: 'app-registerform',
  templateUrl: './registerform.component.html',
  styleUrls: ['./registerform.component.css']
})
export class RegisterformComponent implements OnInit {
      
  empDetails = {} as Empdetails;
  
 

  constructor(private service:EmployeeService, private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.empDetails.Email = this.route.snapshot.params['email'];
  }
  form = {
    password: '',
    confirmPassword: '',
    landmark: ''}

    //Password:string=this.form.password;
    /*Email:String =this.route.snapshot.params['email'];
    Password:String=this.form.password;
    Landmark:String = this.form.landmark;
  
    onSubmit(): void {
      //Taking email from sign up Component
      
      //this.empDetails.Password=this.form.password;
      
      
      this.service.SubmitEmpDetails(this.Email, this.Password, this.Landmark ).subscribe(data=>{
       
      });

      console.log(JSON.stringify(this.form, null, 2));
     
      //this.router.navigate(['/Employeeregister']);


    }*/
   /**hereeee!!!! */
   onSubmit(): void {
    let obj = {
    Email:this.route.snapshot.params['email'],
    Password:this.form.password,
    Landmark:this.form.landmark

    }
   // alert(this.route.snapshot.params['email']);
    this.service.SubmitEmpDetails(obj).subscribe(data=>{
       
    });

    console.log(JSON.stringify(this.form, null, 2));
    alert("Registration from Submitted!!!");
    this.router.navigate(['/start']);
   


   }


}
