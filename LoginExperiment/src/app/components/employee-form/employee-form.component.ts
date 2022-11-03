import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GetDetailsService } from '../../get-details.service';
import { Product } from './product';
import { EmployeeService } from 'src/app/service/employee.service';
import { AllRides } from 'src/app/models/all-rides';
import { ActivatedRoute, Router } from '@angular/router';
import { cabRequestPostData } from 'src/app/models/cab-request-post';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {

  EmpPuid:string=this.route.snapshot.params['Puid'];

  today: Date = new Date();
  productList: Product[] = [];
  cabDetails: AllRides[] = [];
  /*cabRequestPostDataPickUp = {} as cabRequestPostData;
  cabRequestPostDataDrop = {} as cabRequestPostData;*/
  isPickUpCheckBoxSelected: Boolean = false;
  isDropCheckBoxSelected: Boolean = false;
  employee_id: string = '';

  pipe = new DatePipe('en-US');
  todayWithPipe = '';

  constructor(private getDetailsService: GetDetailsService, private employeeService: EmployeeService, private router: Router,private route:ActivatedRoute) {
    this.today.setDate(this.today.getDate() + 1);

    this.todayWithPipe = this.pipe.transform(this.today, 'yyyy-MM-dd') as string;

    //This line is used to display the cab details assigned cabs for pick up
    
    /*
    this.getDetailsService.getProductDetails().subscribe(
      data => {
        this.productList = data;
        console.log(data);
        console.log(this.productList);
      }
    );*/
  }

  ngOnInit(): void {
    Puid:this.route.snapshot.params['Puid'],
    console.log(this.todayWithPipe);
  }

//Function for Logout
  onLogout(): void {
    this.router.navigate(['/']);
  }


  //this function is called when the user submits the cab request
  onCabRequest() {

    //Following is the set of data to be submitted to pickup API
    /*this.cabRequestPostDataPickUp.date = this.today;
    this.cabRequestPostDataPickUp.employeeID= this.employee_id;
    this.cabRequestPostDataPickUp.pickUpStatus = this.isDropCheckBoxSelected;*/

    let pickUpObj=
    {
      Empid:this.EmpPuid,
      pickup:String(this.isPickUpCheckBoxSelected)
    }
    let dropObj=
    {
      Empid:this.EmpPuid,
      drop:String(this.isDropCheckBoxSelected)
    }

    //Following is the set of data to be submitted to drop API
    /*this.cabRequestPostDataDrop.date = this.today;
    this.cabRequestPostDataDrop.employeeID= this.employee_id;
    this.cabRequestPostDataDrop.pickUpStatus = this.isPickUpCheckBoxSelected;*/

    //This subscribes for the service declared in /service/employee -- used to submit cab pick up request
    this.employeeService.submitCabRequestPickUp(pickUpObj).subscribe(
      data => {

      }
    );

    //This subscribes for the service declared in /service/employee -- used to submit cab drop request
    this.employeeService.submitCabRequestDrop(dropObj).subscribe(
      data => {

      }
    );
    alert("Your Request for Cab has been submitted. \nPlease visit in sometime to get updated information about the cab assigned")
    this.router.navigate(['/emp-page-cab-detail', { 'Puid': this.EmpPuid}]);
  }


  setDate(): void {
  }

  ngOnDestroy() {

  }

}
