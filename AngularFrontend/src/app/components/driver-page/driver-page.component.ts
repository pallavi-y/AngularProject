import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/employee';
import { AdminService } from 'src/app/service/admin.service';
import { DriverService } from 'src/app/service/driver.service';

@Component({
  selector: 'app-driver-page',
  templateUrl: './driver-page.component.html',
  styleUrls: ['./driver-page.component.css']
})
export class DriverPageComponent implements OnInit {

  employeePickUpList:Employee[]=[];
  employeeDropList:Employee[]=[];
  constructor( private adminService: AdminService, private router: Router,private driverService:DriverService) { }

  ngOnInit(): void {
    this.adminService.getEmployeePickUpDetails().subscribe(
      data=>{
          this.employeePickUpList=data;
          console.log(data);
          console.log(this.employeePickUpList);
      }
    );
  }

  //Function for logout button
  onLogout(): void{
    this.router.navigate(['/']);
  }

  //this method is called when the pickup time for pick is submitted by the driver
  onSubmitPickUpTime():void{

    console.log(this.employeePickUpList);
    this.driverService.submitPickUpTime(this.employeeDropList).subscribe(data=>{

    });
  }


  
  //this method is called when the pickup time for drop is submitted by the driver
  onSubmitDropTime():void{

    console.log(this.employeePickUpList);
    this.driverService.submitPickUpTime(this.employeePickUpList).subscribe(data=>{

    });
  }
}
