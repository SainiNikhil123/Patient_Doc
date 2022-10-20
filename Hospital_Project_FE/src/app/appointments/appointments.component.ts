import { AppointmentService } from './../Services/appointment.service';
import { Component, OnInit } from '@angular/core';
import { Appointment } from '../Models/appointment';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.scss']
})
export class AppointmentsComponent implements OnInit {

  constructor(private service: AppointmentService) { }

 AppointmentList:Appointment[]=[];

  ngOnInit(): void {
    this.get();
  }

  get()
  {
    this.service.getAllAppointments().subscribe(
      (response)=>{
        this.AppointmentList = response;
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  AddPatients(appointment:any)
  {
    
  }

}
