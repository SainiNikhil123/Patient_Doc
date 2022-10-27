import { Doctor } from "./doctor";

export class Patient {
     id:number = 0;
     appointmentId:number=0;
     name:string="" 
     address:string=""
     phoneNumber:string=""
     departmentId:number=0
     department:string=""
     doctorId:number=0;
     doctor:string="" 
     status:any =""
     comments:any
     refer:number=0
     referName:string=""
     userId:any=""
     doctors:Doctor= new Doctor();
}
