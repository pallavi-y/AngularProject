import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DisplayCabAndDriver } from 'src/app/models/display-cab-and-driver';
import { AdminService } from 'src/app/service/admin.service';

@Component({
  selector: 'app-displaycabanddriver',
  templateUrl: './displaycabanddriver.component.html',
  styleUrls: ['./displaycabanddriver.component.css']
})
export class DisplaycabanddriverComponent implements OnInit {

  constructor(private service:AdminService,private router: Router ) { }
  public DisplayList:DisplayCabAndDriver[] = [];
  // DisplayList=[];
  rideId:number=0;
  
  ngOnInit(): void {
    this.service.GetDisplayCabandDriver().subscribe((
      data=>{
        this.DisplayList= data;

  }));
};

  DeleteRow(ridedata:any):void{
    //this.rideId=ridedata;
    //alert(this.rideId);
    //this.service.DeleteRow(this.displayList.RideId)
    //this.service.DeleteRow(ridedata.rideId).subscribe(data=>
    this.service.DeleteRow(ridedata).subscribe(data=>
      {
         console.log(ridedata);
          

      });
      alert("Deleted Succcessfully");
   
      this.service.GetDisplayCabandDriver().subscribe((
        data=>{
          this.DisplayList= data;
        console.log(this.DisplayList);
  
    }));
    

  }
}
