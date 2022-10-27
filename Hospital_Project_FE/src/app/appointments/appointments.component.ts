import { NewPatient } from './../Models/new-patient';
import { Patient } from './../Models/patient';
import { AppointmentService } from './../Services/appointment.service';
import { Component, OnInit } from '@angular/core';
import { Appointment } from '../Models/appointment';
import { Doctor } from '../Models/doctor';
import { Department } from '../Models/department';
import { PatientService } from '../Services/patient.service';
import { DepartmentService } from '../Services/department.service';
import { DoctorService } from '../Services/doctor.service';
import { empty } from 'rxjs';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.scss']
})
export class AppointmentsComponent implements OnInit {

  patient:NewPatient=new NewPatient();
  AllDoctors:Doctor[]=[];
  DoctorsByDep:Doctor[]=[];
  DepartmentList:Department[]=[];

  constructor(private service: AppointmentService,private patientService:PatientService, private departmentService:DepartmentService, private doctorService: DoctorService) { }

 AppointmentList:Appointment[]=[];

  ngOnInit(): void {
    this.get();
    this.getAllDep();
    this.getAllDoc();
    this.onSelectDep(0);
    this.onSelectDoc(0);
   
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

  AddPatients(appointment:Appointment)
  {
    this.patient.userId = appointment.userId;
    this.patient.address = appointment.address;
    this.patient.appointmentId = appointment.id;
    this.patient.phoneNumber = appointment.phoneNumber;
    this.patient.name = appointment.patientName;
    this.patient.departmentId = appointment.departmentId;
  }

  onSubmit()
  {
    this.patientService.postPatient(this.patient).subscribe(
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

  onSelectDep(e:any)
  {
    //console.log(e.target.value);
    this.patient.departmentId = e.target.value;
    this.DoctorsByDep = this.AllDoctors.filter(x=>x.departmentId == e.target.value);
    console.log(this.DoctorsByDep)
  }

  onSelectDoc(e:any)
  {
    this.patient.doctorId = e.target.value;
  }


}
