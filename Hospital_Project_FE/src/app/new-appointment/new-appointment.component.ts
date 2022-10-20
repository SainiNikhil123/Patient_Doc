import { Appointment } from './../Models/appointment';
import { Time } from './../Models/time';
import { AppointmentService } from './../Services/appointment.service';
import { Department } from './../Models/department';
import { DoctorService } from './../Services/doctor.service';
import { DepartmentService } from './../Services/department.service';
import { Component, OnInit } from '@angular/core';
import { Doctor } from '../Models/doctor';

@Component({
  selector: 'app-new-appointment',
  templateUrl: './new-appointment.component.html',
  styleUrls: ['./new-appointment.component.scss']
})
export class NewAppointmentComponent implements OnInit {

  AllDoctors:Doctor[]=[];
  DoctorsByDep:Doctor[]=[];
  DepartmentList:Department[]=[];
  TimeList:Time[]=[];
  newAppointment:Appointment = new Appointment();
  date: string | number | Date | undefined;

  constructor(private departmentService: DepartmentService, private doctorService: DoctorService, private appointmentService: AppointmentService) { }

  ngOnInit(): void {
    this.date = new Date().toISOString().slice(0, 10);
    this.getAllDep();
    this.getAllDoc();
    this.getTIme();
    this.onSelectDep(0);
  }

  addAppointment()
  {
    let id = localStorage.getItem("Id");
    this.newAppointment.userId = id;
    this.appointmentService.addAppointments(this.newAppointment).subscribe(
      (response)=>{
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    )

  }

  getAllDoc()
  {
    this.doctorService.getAllDoctors().subscribe(
      (response)=>{
        this.AllDoctors = response
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getAllDep()
  {
    this.departmentService.getAllDepartment().subscribe(
      (response)=>{
        this.DepartmentList = response;
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getTIme()
  {
    this.appointmentService.getTime().subscribe(
      (response)=>{
        this.TimeList = response;
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  onSelectDep(e:any)
  {
    //console.log(e.target.value);
    this.newAppointment.departmentId = e.target.value;
    this.DoctorsByDep = this.AllDoctors.filter(x=>x.departmentId == e.target.value);
    console.log(this.DoctorsByDep)
  }

  onSelectDoc(e:any)
  {
    this.newAppointment.doctorId = e.target.value;
  }

  onTimeSelect(e:any)
  {
    console.log(e.target.value);
    this.newAppointment.appointmentTimes = e.target.value;
  }

}
