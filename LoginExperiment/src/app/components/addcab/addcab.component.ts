import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/service/admin.service';
import { EmployeeService } from 'src/app/service/employee.service';

@Component({
  selector: 'app-addcab',
  templateUrl: './addcab.component.html',
  styleUrls: ['./addcab.component.css']
})
export class AddcabComponent implements OnInit {

  constructor(private service:AdminService,private router: Router) { }

  ngOnInit(): void {
  }
  form = {
    cabNum: '',
    cabName: '',
    seats:'',
    engineType:'',
    fuel:'',
    vehicleStatus:''
   }
   
  
   
    onSubmit(): void {
        

      let obj ={
        cabNumber:this.form.cabNum,
        cabName:this.form.cabName,
        no_of_Seats:this.form.seats,
        engine_Type:this.form.engineType=="Diesel"?true:false,
        fuelled:this.form.fuel=="Yes"?true:false,
        vehicle_Status:this.form.vehicleStatus=="Active"?true:false

      }
      this.service.addCab(obj).subscribe(data=>{
        
      });
      console.log(JSON.stringify(this.form, null, 2));
      alert("The Details Have Been Submitted");
      
    }
   
  
    /**openPopup() {
      this.displayStyle = "block";
    }*/
  }
