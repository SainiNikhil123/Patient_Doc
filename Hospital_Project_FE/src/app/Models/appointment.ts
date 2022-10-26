import { EmptyError } from 'rxjs';
import { Doctor } from './doctor';
export class Appointment {
    userId:any;
    id:number;
    patientName:string;
    phoneNumber:string;
    address:string;
    departmentId:number;
    department:string;
    doctorId:number;
    doctor:string;
    appointmentDate:any;
    appointmentTimes:number;
    time:string;
   

    constructor(){
        this.userId="";
        this.id=0;
        this.patientName="";
        this.phoneNumber="";
        this.address="";
        this.departmentId=0;
        this.department="";
        this.doctorId=0;
        this.doctor="";
        this.appointmentDate="";
        this.appointmentTimes=0;
        this.time="";
        
    }
}
