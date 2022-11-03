import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from './components/employee-form/product';

@Injectable({
  providedIn: 'root'
})
export class GetDetailsService {

  constructor(private http: HttpClient) { }

  getProductDetails():Observable<Product[]>
  {
  return this.http.get<Product[]>('http://localhost:11555/api/Products');
	//.subscribe(data => {
		//console.log(data);
	//});
}


}
