import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AssignedCabToDriver } from 'src/app/models/assigned-cab-to-driver';
import { CabDetails } from 'src/app/models/cab-details';
import { Driver } from 'src/app/models/driver-info';
import { AdminService } from 'src/app/service/admin.service';
import { DriverService } from 'src/app/service/driver.service';

@Component({
  selector: 'app-assigncabtodriver',
  templateUrl: './assigncabtodriver.component.html',
  styleUrls: ['./assigncabtodriver.component.css'],
})
export class AssigncabtodriverComponent implements OnInit {
  Driver: Driver[] = [];
  Cab: CabDetails[] = [];
  // Driver=[];
  // Cab={
  //   "cabId":String,
  //   "cabNumber":String,
  //   "cabName":String
  // };
  /*SelectedPair={} as AssignedCabToDriver;*/
  SelectedCab: string = '';
  SelectedDriver: string = '';

  constructor(
    private adminService: AdminService,
    private driverService: DriverService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.adminService.GetCabDetails().subscribe((data) => {
      this.Cab = data;
    });

    this.driverService.GetDriverDetails().subscribe((data) => {
      this.Driver = data;
    });
  }

  ChangeCab(data: any) {
    this.SelectedCab = data;
   
  }

  ChangeDriver(data: any) {
    this.SelectedDriver = data;
    
  }
  Submit(): void {
    let obj = 
    {
      CabId:this.SelectedCab.substring(0,this.SelectedCab.indexOf("-")),
      DriverId:this.SelectedDriver.substring(0,this.SelectedDriver.indexOf("-"))
  
    }
    this.adminService.SubmitAssignedDetails(obj).subscribe(data=>
      {
        
      });
      //alert(this.SelectedPair.SelectedCab+ "" +this.SelectedPair.SelectedDriver);

      this.adminService.GetCabDetails().subscribe((data) => {
        this.Cab = data;
      });
  
      this.driverService.GetDriverDetails().subscribe((data) => {
        this.Driver = data;
      });
     alert('Successfully assigned cab to driver!!!');
     this.router.navigate(['/displaycabanddriver']); 

  }
}
