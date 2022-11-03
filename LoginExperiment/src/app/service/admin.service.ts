import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AvailableRides } from '../models/available-rides';
import { CabDetails } from '../models/cab-details';
import { DisplayCabAndDriver } from '../models/display-cab-and-driver';
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
  readonly apiurl="http://localhost:64652/api/CabService/";
  constructor(private http: HttpClient) { }

  //This function populates the table with the list of employees that opted for pickup 
  //Structure of data defined in /models/Employee
  getEmployeePickUpDetails():Observable<Employee[]>
  {  return this.http.get<Employee[]>(this.apiurl+'PickUpEnabledEmployees');}


  //This function populates the table with the list of employees that opted for pickup 
  //Structure of data defined in /models/Employee
  getEmployeeDropDetails():Observable<Employee[]>
  {  return this.http.get<Employee[]>(this.apiurl+'DropEnabledEmployees');}



  getAvailablePickUpRides():Observable<AvailableRides[]>{
    return this.http.get<AvailableRides[]>(this.apiurl+'GetAllPickUpAvailableRides');
  }

  getAvailableDropRides():Observable<AvailableRides[]>{
    return this.http.get<AvailableRides[]>(this.apiurl+'GetAllDropAvailableRides');
  }
  

//This function takes the details of the driver that is filled by the admin (includes the cab assigned also)
addDriver(data:any):Observable<any>{
   console.log(data);
   return this.http.post<any>(this.apiurl+'AddDriver',data);
  
}

//this function takes the details of the cab which is filled by the admin
addCab(data: any):Observable<any>{
  console.log(data);
  return this.http.post<any>(this.apiurl+"AddCab",data);
}




//this function populates the cab and driver data into table
GetDisplayCabandDriver():Observable<any>
{
 
  return this.http.get<any>(this.apiurl+"GetAllAssignedCarDriverPairs");
}

//this function used to delete the row 
DeleteRow(rideId:number):Observable<any>
{
  let obj={
    rideId:rideId.toString()
  }
  return this.http.post<any>(this.apiurl+"DeleteRide",obj);
}

//this function populates in drop dop about cab details
GetCabDetails():Observable<any>
{
    return this.http.get<any>(this.apiurl+'UnassignedCabs');
}

//sumit cab and driver assigned details
SubmitAssignedDetails(data:any):Observable<any>
{
    return this.http.patch<any>(this.apiurl+'AddRide',data);
}

//this function used for assigning cab to emp - changing the occupied seats
updatePickUpTable(cab:any):Observable<any>{
  console.log(cab);
  return this.http.patch<any>(this.apiurl+'AddEmployeePickUpDetails',cab);
 
}

updateDropTable(cab:any):Observable<any>{
  console.log(cab);
  return this.http.patch<any>(this.apiurl+'AddEmployeeDropDetails',cab);
 
}

//function to reset data
resetData():Observable<any>{
  return this.http.get<any>(this.apiurl+"ResetData");
}
}

