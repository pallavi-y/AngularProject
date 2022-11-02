import { Common } from "./common";

export interface Employee extends Common{
    employee_id:string,
    Landmark_id:string,
    Assigned_ride_no:string,
    Pick_up_time: string
}