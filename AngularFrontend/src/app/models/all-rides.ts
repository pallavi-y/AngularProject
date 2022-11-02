import { Common } from "./common";

export interface AllRides extends Common{
cab_id:string,
cab_name:string,
driver_id:string,
Driver_name:string,
seats:number,
owned:boolean
}
