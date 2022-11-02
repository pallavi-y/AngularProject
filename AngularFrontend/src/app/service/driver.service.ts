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
  providedIn: 'root'
})
export class DriverService {

  fakeurl=""
  constructor(private http: HttpClient) { }


  
  //This function is called to submit both - pick up time for pickup as well as drop
submitPickUpTime(pickUpDetails: Employee[]):Observable<Employee[]>{
  console.log(pickUpDetails);

  //Replace the given url with your URL to submit the data
  return this.http.post<Employee[]>(this.fakeurl+'add-driver-post-data.json',pickUpDetails);
 
}

}
