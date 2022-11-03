import { Common } from "./common";

export interface AllRides extends Common{
    cab_id:string,
    cab_name:string,
    driver_id:string,
    Driver_name:string,
    pick_up_time: string;
    seats:number,
    owned:boolean

    cabNumber:string,
driverAltContactNumber:number,

driverContactNumber:number,

driverName:string,
expectedPickUpTime: string
}
