import { Component, OnInit } from '@angular/core';
import { AvailableRides } from 'src/app/models/available-rides';
import { Employee } from 'src/app/models/employee';
import { AdminService } from 'src/app/service/admin.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  
 // ridesAvailableList=["cab1","cab2","cab3"];
  ridesAvailableList:AvailableRides[] =[];
  employeePickUpList:Employee[]=[];
  constructor(private adminService: AdminService) { }

  ngOnInit(): void {

    //This code subscribes to service defined in /service/admin ---Used to populate the table with the list of employees that opt for cab service
    this.adminService.getEmployeePickUpDetails().subscribe(
      data=>{
          this.employeePickUpList=data;
          console.log(data);
          console.log(this.employeePickUpList);
      }
    );

    
    this.adminService.getAvailableRides().subscribe(
      data=>{
          this.ridesAvailableList= data;
          console.log(data);
          console.log(this.employeePickUpList);
      }
    );



    
  }
  onSubmitRides(){
    console.log(this.employeePickUpList);
    alert("DATA SUBMITTED");
  }

}
