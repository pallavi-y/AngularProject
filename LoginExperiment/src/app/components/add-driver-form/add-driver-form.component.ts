import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Driver } from 'src/app/models/driver-info';
import { AdminService } from 'src/app/service/admin.service';

@Component({
  selector: 'app-add-driver-form',
  templateUrl: './add-driver-form.component.html',
  styleUrls: ['./add-driver-form.component.css']
})
export class AddDriverFormComponent implements OnInit {

  FullName:string='';


  //"Driver" in the below line is the name of the model (/model/Driver) that defines the structure of the data to be submitted
  driverInfo = {} as Driver;

 driverForm = {}as FormGroup;
  first_name = {} as FormControl;
  last_name={}as FormControl;
  phone={} as FormControl;
  altphone={} as FormControl;
  email = {} as FormControl;
  location ={} as FormControl;
  age ={} as FormControl;
  //agency ={} as FormControl;
  dob ={} as FormControl;
  constructor(private adminService: AdminService,private router: Router) { 
 
  }

  //Function called when logout button is clicked
  onLogout(): void{
    this.router.navigate(['/']);
  }
 
  ngOnInit(): void {

    //This code fragment initializes the controls
    this.first_name=new FormControl();
    this.last_name=new FormControl();
    this.phone = new FormControl();
    this.email = new FormControl();
    //this.agency= new FormControl();
    this.dob=new FormControl();
    this.age = new FormControl();
    this.location= new FormControl();
    this.altphone = new FormControl();

    //This code fragment binds each element of the form with the form
    this.driverForm = new FormGroup({
      first_name:this.first_name,
      last_name:this.last_name,
      phone:this.phone,
      altphone:this.altphone,
      email:this.email,
      //agency:this.agency,
      dob:this.dob,
      location :this.location,
      age: this.age
    });
  }


  //This function is called when the submit button is clicked
  OnAddDriverDetails(data:any):void{
    this.FullName= data.first_name + " " + data.last_name;
    let DriverObj={
      driverName:this.FullName,
      phoneNumber:data.phone,
      alt_PhoneNumber:data.altphone,
      location: data.location,
      emailAddress:data.email,
      password:data.dob,
      age:data.age

    }
    
    
    /*this.driverInfo.FirstName = data.first_name;
    this.driverInfo.LastName = data.last_name;
    this.driverInfo.Name=this.FullName;
    this.driverInfo.Phone = data.phone;
    this.driverInfo.Email = data.email;
    this.driverInfo.AltPhone = data.altphone;
    this.driverInfo.Location = data.location;
    this.driverInfo.Age = data.age;
    this.driverInfo.Dob = data.dob;*/

//Subscription for service declared in /service/driver
//Submits the details entered in the form
  this.adminService.addDriver(DriverObj).subscribe(data=>{
    console.log(data);
  });
  alert("The Details Have Been Submitted\nEmail:"+data.email+"\nPassword:"+data.dob);
  this.driverForm.reset();
  this.router.navigate(['/add-user']);
  }




}
