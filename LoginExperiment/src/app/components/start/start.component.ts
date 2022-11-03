import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/service/admin.service';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent implements OnInit {

  constructor(private service:AdminService) { }

  ngOnInit(): void {
    /**const currentDate = new Date();
    const hours = currentDate.getHours();
   if(hours==0)
   {
      this.service.resetData().subscribe(data=>
        {

        });
   }
  */

}
}
