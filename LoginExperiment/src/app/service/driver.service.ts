import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';
import { AvailableRides } from '../models/available-rides';
import { Driver } from '../models/driver-info';
import { HttpClient } from '@angular/common/http';

/*--------------------------------------------------------
---------------------------------------------All the services that are used to get and post data on the driver page 
                                             of the portal are declared and defined here
----------------------------------------------*/

@Injectable({
  providedIn: 'root',
})
export class DriverService {
  fakeurl = '/assets/fake-data/';
  readonly apiurl = 'http://localhost:64652/api/CabService/';
  constructor(private http: HttpClient) {}

  //This function is called to submit both - pick up time for pickup as well as drop
  /*submitPickUpTime(pickUpDetails: Employee[]):Observable<Employee[]>{
  console.log(pickUpDetails);

  //Replace the given url with your URL to submit the data
  return this.http.post<Employee[]>(this.fakeurl+'add-driver-post-data.json',pickUpDetails);
 
}*/

  //Method to populate the pickup table of the driver
  getEmployeePickUpDetails(email: string): Observable<Employee[]> {
    let obj={
      Email:email
    }
    return this.http.patch<Employee[]>(
      this.apiurl + 'PickUpsAssignedForDriver',
      obj
    );
  }

  //Method to populate the drop table of the driver
  getEmployeeDropDetails(email: string): Observable<Employee[]> {
    let obj={
      Email:email
    }
    return this.http.patch<Employee[]>(
      this.apiurl + 'DropsAssignedForDriver',
      obj
    );
  }

  //function to get Driver Details to populate in drop down
  GetDriverDetails(): Observable<any> {
    return this.http.get<any>(this.apiurl + 'UnassignedDrivers');
  }

  //function to pass driver login verification
  SubmitDriverLogin(data: any): Observable<any> {
    //Change the url
    //after this.url , add ur extra path
    console.log(data);
    return this.http.patch<any>(this.apiurl + 'LoginDriver', data);
  }
  //function gets all cab details to populate into form

  GetDriverCabInfo(Email: any): Observable<any> {
    let obj={
      email :Email.toString()
    }
    return this.http.patch<any>(
      this.apiurl + 'CabDetailsAssignedForDriver',obj
    );
  }
  SubmitActualPickup(data: any): Observable<any> {
    console.log();
    return this.http.patch<any>(this.apiurl + 'setPickUpActualTime', data);
  }

  SubmitActualDrop(data: any): Observable<any> {
    console.log();
    return this.http.patch<any>(this.apiurl + 'setDropActualTime', data);
  }
  SubmitExpectedPickUP(data: any): Observable<any> {
    console.log();
    return this.http.patch<any>(this.apiurl + 'setPickUpExpectedTime', data);
  }
}
