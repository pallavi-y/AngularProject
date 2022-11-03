import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AvailableRides } from 'src/app/models/available-rides';
import { Employee } from 'src/app/models/employee';
import { AdminService } from 'src/app/service/admin.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
})
export class EmployeeListComponent implements OnInit {
  selectedValue: string = '';
  radiovalue: string = '';
  // ridesAvailableList=["cab1","cab2","cab3"];
  PickUpridesAvailableList: AvailableRides[] = [];
  DropridesAvailableList: AvailableRides[] = [];
  employeePickUpList: Employee[] = [];
  employeeDropList: Employee[] = [];
  constructor(private adminService: AdminService, private route: Router) {}

  ngOnInit(): void {
    //This code subscribes to service defined in /service/admin ---Used to populate the table with the list of employees that opt for cab service
    this.adminService.getEmployeePickUpDetails().subscribe((data) => {
      this.employeePickUpList = data;

      console.log(this.employeePickUpList);
    });
    //Sends the value selected in the drop down to the API
    this.adminService.getEmployeeDropDetails().subscribe((data) => {
      this.employeeDropList = data;

      console.log(this.employeeDropList);
    });

    //used to repopulate the dropdown by calling the API again
    this.adminService.getAvailablePickUpRides().subscribe((data) => {
      this.PickUpridesAvailableList = data;
      console.log(data);
      console.log(this.PickUpridesAvailableList);
    });
    this.adminService.getAvailableDropRides().subscribe((data) => {
      this.DropridesAvailableList = data;
      console.log(data);
      console.log(this.DropridesAvailableList);
    });
  }

  async myFunctionPickUp(selectValue: string, puid: string) {
   

    let pickUpObj = {
      RideId: selectValue,
      Empid: puid,
    };

    /*this.adminService.updateCabList(selectValue).subscribe(
    data => {
      console.log(data);
        }
  );*/

    await this.adminService.updatePickUpTable(pickUpObj).subscribe((data) => {});
    window.location.reload();
  //  this.adminService.getAvailablePickUpRides().subscribe((data) => {
  //     this.PickUpridesAvailableList = data;
  //     console.log(data);
  //     console.log(this.PickUpridesAvailableList);
  //   });
    
  //   this.adminService.getAvailablePickUpRides().subscribe((data) => {
  //     this.PickUpridesAvailableList = data;
  //     console.log(data);
  //     console.log(this.PickUpridesAvailableList);
  //   });
  }

  async myFunctionDrop(selectValue: string, puid: string) {
    let dropObj = {
      RideId: selectValue,
      Empid: puid,
    };
   

    await this.adminService.updateDropTable(dropObj).subscribe((data) => {});
    window.location.reload();
    // this.adminService.getAvailableDropRides().subscribe((data) => {
    //   this.DropridesAvailableList = data;
    //   console.log(data);
    //   console.log(this.DropridesAvailableList);
    // });
    // setTimeout(this.adminService.getAvailableDropRides,4000);
    // this.adminService.getAvailableDropRides().subscribe((data) => {
    //   this.DropridesAvailableList = data;
    //   console.log(data);
    //   console.log(this.DropridesAvailableList);
   // });
  }

  onSubmitPickupRides() {
    console.log(this.employeePickUpList);
    alert('DATA SUBMITTED');
    
  }

  onSubmitDropRides() {
    console.log(this.employeeDropList);
    alert('DATA SUBMITTED');
  }
}
