import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/models/employee';
import { AdminService } from 'src/app/service/admin.service';
import { DriverService } from 'src/app/service/driver.service';

@Component({
  selector: 'app-driver-page',
  templateUrl: './driver-page.component.html',
  styleUrls: ['./driver-page.component.css']
})
export class DriverPageComponent implements OnInit {
  
  Email:string=this.route.snapshot.params['Email'];
  Name:string=this.route.snapshot.params['Name'];
  Drop_time:string="";
  ActualPickup:string="";
  ActualDrop:string="";
  ExpectedPickup:string="";
  employeePickUpList:Employee[]=[];
  employeeDropList:Employee[]=[];
  constructor( private adminService: AdminService, private router: Router,private driverService:DriverService, private route:ActivatedRoute ){ }

  ngOnInit(): void {

    this.driverService.getEmployeePickUpDetails(this.Email).subscribe(
      data=>{
          this.employeePickUpList=data;
        
          console.log(data);
          console.log(this.employeePickUpList);
      }
    );

    this.driverService.getEmployeeDropDetails(this.Email).subscribe(
      data=>{
          this.employeeDropList= data;
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
    alert("Details Updated");
    //console.log(this.employeePickUpList);
    // this.driverService.submitPickUpTime(this.employeeDropList).subscribe(data=>{

    // });
  }


  
  //this method is called when the pickup time for drop is submitted by the driver
  onSubmitDropTime():void{
    alert("Details Updated");
   // console.log(this.employeePickUpList);
    // this.driverService.submitPickUpTime(this.employeePickUpList).subscribe(data=>{

    // });

  }

SetActualPickup(Puid:string,ActualPickup:string):void{
  let obj={
    Empid:Puid,
    ActualTime:ActualPickup
  };
  this.driverService.SubmitActualPickup(obj).subscribe(data=>
    {

    });

    this.driverService.getEmployeePickUpDetails(this.Email).subscribe(
      data=>{
          this.employeePickUpList=data;
        
          console.log(data);
          console.log(this.employeePickUpList);
      }
    );
    window.location.reload();

}

SetExpectedPickup(Puid:string,ExpectedPickUp:string):void{
  let obj={
    Empid:Puid,
    ExpectedTime:ExpectedPickUp
  };
  this.driverService.SubmitExpectedPickUP(obj).subscribe(data=>
    {

    });

    this.driverService.getEmployeePickUpDetails(this.Email).subscribe(
      data=>{
          this.employeePickUpList=data;
        
          console.log(data);
          console.log(this.employeePickUpList);
      }
    );
    window.location.reload();
}

SetActualDrop(Puid:string,ActualDrop:string):void{
  let obj={
    Empid:Puid,
    ActualTime:ActualDrop
  };
  this.driverService.SubmitActualDrop(obj).subscribe(data=>
    {

    });

    this.driverService.getEmployeeDropDetails(this.Email).subscribe(
      data=>{
          this.employeeDropList= data;
          console.log(data);
          console.log(this.employeePickUpList);
      }
    );
    window.location.reload();
}
}
