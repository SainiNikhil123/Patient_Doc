import { Appointment } from './../Models/appointment';
import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../Services/appointment.service';

@Component({
  selector: 'app-my-appointment',
  templateUrl: './my-appointment.component.html',
  styleUrls: ['./my-appointment.component.scss']
})
export class MyAppointmentComponent implements OnInit {

  constructor(private service: AppointmentService) { }
  
  MyAppointmentList:Appointment[]=[];

  ngOnInit(): void {
    this.getAppointment();
  }

  getAppointment()
  {
    var id = localStorage.getItem("Id");
    this.service.getAppointmentById(id).subscribe(
      (response)=>{
        this.MyAppointmentList = response;
        console.log(this.MyAppointmentList)
      },
      (error)=>{
        console.log(error);
      }
    )
  }

}
