import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DisplayCabAndDriver } from 'src/app/models/display-cab-and-driver';
import { DriverService } from 'src/app/service/driver.service';

@Component({
  selector: 'app-driver-car-info',
  templateUrl: './driver-car-info.component.html',
  styleUrls: ['./driver-car-info.component.css']
})
export class DriverCarInfoComponent implements OnInit {
  EngineType:string="";
  Fuel:string="";
  WorkingStatus:string="";

  DriverCarInfo={}as DisplayCabAndDriver;
  Email:string=this.route.snapshot.params['Email'];
  Name:string=this.route.snapshot.params['Name'];

  constructor(private router:Router, private route: ActivatedRoute, private service:DriverService) { }

  ngOnInit(): void {

    this.service.GetDriverCabInfo(this.Email).subscribe(
      data => {
        this.DriverCarInfo = data;
        console.log(data);
        if(data.CabNumber=='-')
        {
          this.EngineType=data.Engine_Type;
          this.Fuel=data.Fuelled;
          this.WorkingStatus=data.Vehicle_Status;
      
        }
        else
        {
          this.EngineType=data.engine_Type==true?"Diesel":"Petrol";
          this.Fuel=data.fuelled==true?"Full":"Empty";
          this.WorkingStatus=data.vehicle_Status==true?"Active":"Broken";
      
        }
         }
    );
  }

  onLogout(): void {
     
    this.router.navigate(['/']);
  }
}


        
     
    

    