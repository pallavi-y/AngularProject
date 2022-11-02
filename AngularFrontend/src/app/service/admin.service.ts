import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AvailableRides } from '../models/available-rides';
import { Driver } from '../models/driver-info';
import { Employee } from '../models/employee';



/*--------------------------------------------------------
--------------------------------------------------All the services that are used to get and post data on the admin side 
                                                  of the portal are declared and defined here
----------------------------------------------*/





@Injectable({
  providedIn: 'root'
})
export class AdminService {

  fakeurl='/assets/fake-data/';

  url='http://localhost:11555';
  constructor(private http: HttpClient) { }

  //This function populates the table with the list of employees that opted for pickup 
  //Structure of data defined in /models/Employee
  getEmployeePickUpDetails():Observable<Employee[]>
  {  return this.http.get<Employee[]>(this.fakeurl+'pickup.json');}



  getAvailableRides():Observable<AvailableRides[]>{
    return this.http.get<AvailableRides[]>(this.fakeurl+'pickup.json');
  }
  

//This function takes the details of the driver that is filled by the admin (includes the cab assigned also)
addDriver(driverDetails: Driver):Observable<any>{
   console.log(driverDetails);
   return this.http.post<any>(this.fakeurl+'add-driver-post-data.json',driverDetails);
  
}
}

