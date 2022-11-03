import { Common } from "./common";

export interface cabRequestPostData extends Common{
date: Date,
pickUpStatus: Boolean,
employeeID: string
}
