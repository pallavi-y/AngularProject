import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GetDetailsService } from '../../get-details.service';
import { Product } from './product';
import { EmployeeService } from 'src/app/service/employee.service';
import { AllRides } from 'src/app/models/all-rides';
import { Router } from '@angular/router';
import { cabRequestPostData } from 'src/app/models/cab-request-post';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {


  today: Date = new Date();
  productList: Product[] = [];
  cabDetails: AllRides[] = [];
  cabRequestPostDataPickUp = {} as cabRequestPostData;
  cabRequestPostDataDrop = {} as cabRequestPostData;
  isPickUpCheckBoxSelected: Boolean = false;
  isDropCheckBoxSelected: Boolean = false;

  pipe = new DatePipe('en-US');
  todayWithPipe = '';

  constructor(private getDetailsService: GetDetailsService, private employeeService: EmployeeService, private router: Router) {
    this.today.setDate(this.today.getDate() + 1);

    this.todayWithPipe = this.pipe.transform(this.today, 'yyyy-MM-dd') as string;

    //This line is used to display the cab details assigned cabs for pick up
    this.employeeService.getEmployeePickUpDetails().subscribe(
      data => {
        this.cabDetails = data;
        console.log(this.cabDetails);
      }
    );
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

    console.log(this.todayWithPipe);



  }

  onLogout(): void {
    this.router.navigate(['/']);
  }


  //this function is called when the user submits the cab request
  onCabRequest() {
    this.cabRequestPostDataPickUp.date = this.today;
    this.cabRequestPostDataPickUp.pickUpStatus = this.isDropCheckBoxSelected;
    this.cabRequestPostDataDrop.date = this.today;
    this.cabRequestPostDataDrop.pickUpStatus = this.isPickUpCheckBoxSelected;

    //This subscribes for the service declared in /service/employee -- used to submit cab pick up request
    this.employeeService.submitCabRequestPickUp(this.cabRequestPostDataPickUp).subscribe(
      data => {

      }
    );

    //This subscribes for the service declared in /service/employee -- used to submit cab drop request
    this.employeeService.submitCabRequestDrop(this.cabRequestPostDataDrop).subscribe(
      data => {

      }
    );
    alert("Your Request for Cab has been submitted. \nPlease visit in sometime to get updated information about the cab assigned")
 
  }


  setDate(): void {
  }

  ngOnDestroy() {

  }

}
