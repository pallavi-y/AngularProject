import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AllRides } from 'src/app/models/all-rides';
import { EmployeeService } from 'src/app/service/employee.service';

@Component({
  selector: 'app-employee-page-cab-details',
  templateUrl: './employee-page-cab-details.component.html',
  styleUrls: ['./employee-page-cab-details.component.css']
})
export class EmployeePageCabDetailsComponent implements OnInit {
cabPickUpDetails = {} as AllRides;
    cabDropDetails = {} as AllRides;
    // cabPickUpDetails={};
    // cabDropDetails={};
    EmpPuid:string=this.route.snapshot.params['Puid'];

    

    constructor(private employeeService: EmployeeService, private router:Router,private route:ActivatedRoute) { }
  
    ngOnInit(): void {
        
     
      this.employeeService.getEmployeePickUpDetails(this.EmpPuid).subscribe(
        data => {
          this.cabPickUpDetails = data;
          console.log(data);
        }
      );

      this.employeeService.getEmployeeDropDetails(this.EmpPuid).subscribe(
        data => {
          this.cabDropDetails = data;
          console.log(data);
        }
      );
    }
    //Function for Logout
    onLogout(): void {
     
      this.router.navigate(['/']);
    }
  
  }

