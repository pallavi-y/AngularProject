import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AllRides } from '../models/all-rides';
import { cabRequestPostData } from '../models/cab-request-post';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  fakeurl='/assets/fake-data/';
  url='http://localhost:11555';
  constructor(private http: HttpClient) { }


  //This function fetches the details of the cab that is assigned to the employee for pickup
  getEmployeePickUpDetails():Observable<AllRides[]>
  {

  return this.http.get<AllRides[]>(this.fakeurl+'assigned-cab.json');

}

//Submits cab request by employee (date, is pickup checked, is drop checked)
submitCabRequestPickUp(data: cabRequestPostData):Observable<cabRequestPostData>{
  console.log(data);
  return this.http.post<cabRequestPostData>(this.fakeurl+'add-driver-post-data.json',data);
 
}

submitCabRequestDrop(data: cabRequestPostData):Observable<cabRequestPostData>{
  console.log(data);
  return this.http.post<cabRequestPostData>(this.fakeurl+'add-driver-post-data.json',data);
 
}



//This function will be used to submit the details to the api ---Replace fakeurl with actual URL
displayCabDetails():Observable<any>{
  
   return this.http.get<any>(this.fakeurl+'add-driver-post-data.json');
  
}
}

