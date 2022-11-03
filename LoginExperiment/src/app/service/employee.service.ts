import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AllRides } from '../models/all-rides';
import { cabRequestPostData } from '../models/cab-request-post';
import { Empdetails } from '../models/empdetails';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  fakeurl='/assets/fake-data/';
  url='http://localhost:11555';
  readonly apiurl="http://localhost:64652/api/CabService/";
  constructor(private http: HttpClient) { }


  //This function fetches the details of the cab that is assigned to the employee for pickup
  getEmployeePickUpDetails(Empid:any):Observable<any>
  {
    let obj={
      Empid:Empid
    }
  return this.http.patch<any>(this.apiurl+'GetEmployeePickUpCabDetails',obj);

}

getEmployeeDropDetails(Empid:any):Observable<any>
{
  let obj={
    Empid:Empid
  }
return this.http.patch<any>(this.apiurl+'GetEmployeeDropCabDetails',obj);

}

//Submits cab request by employee (date, is pickup checked, is drop checked)
submitCabRequestPickUp(data: any):Observable<any>{
  console.log(data);
  return this.http.patch<any>(this.apiurl+'EmployeePickUpStatus',data);
 
}

submitCabRequestDrop(data:any):Observable<any>{
  console.log(data);
  return this.http.patch<any>(this.apiurl+'EmployeeDropStatus',data);
 
}



//This function will be used to submit the details to the api ---Replace fakeurl with actual URL
/*displayCabDetails():Observable<any>{
  
   return this.http.get<any>(this.fakeurl+'add-driver-post-data.json');
  
}*/

//Submits employee sign up details (email,passsword, landmark )
SubmitEmpDetails(data :any):Observable<any>{
 
  //Change the url 
  //after this.url , add ur extra path
  console.log(data);
  return this.http.post<any>(this.apiurl +"RegisteredEmployee", data);
}

//This function will be used verify the email existance
getemail(email:string):Observable<any>
{
  console.log(email);
  return this.http.get<any>(this.apiurl+email);
}

//Submits employee sign up details (email,passsword, landmark )
SubmitEmpLogin(data :any):Observable<any>{
 
  //Change the url 
  //after this.url , add ur extra path
  console.log(data);
  return this.http.patch<any>(this.apiurl+"LoginEmployee",data);
}



}

