import { Router } from '@angular/router';
import { Appointment } from './../Models/appointment';
import { Time } from './../Models/time';
import { AppointmentService } from './../Services/appointment.service';
import { Department } from './../Models/department';
import { DoctorService } from './../Services/doctor.service';
import { DepartmentService } from './../Services/department.service';
import { Component, OnInit } from '@angular/core';
import { Doctor } from '../Models/doctor';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';

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
  Registrationform !: FormGroup;
  //submitted:boolean=false;
  //stars:number[] = [1,2,3,4,5];
  //rating:number=0;

  constructor(private fb:FormBuilder,private departmentService: DepartmentService, private doctorService: DoctorService, private appointmentService: AppointmentService, private router :Router) { 
    this.CreateForm();
  }

  ngOnInit(): void {
    this.date = new Date().toISOString().slice(0, 10);
    this.getAllDep();
    this.getAllDoc();
    this.getTIme();
    this.onSelectDep(0);
    this.onSelectDoc(0);
    this.CreateForm();
   
  }

  CreateForm()
  {
    this.Registrationform = this.fb.group({
      name: ['', Validators.required ],
      phoneNumber: ['', Validators.required ],
      Address: ['', Validators.required ],
      Department:['', Validators.required ],
      doctor:['', Validators.required ],
  })

  }

  // onSubmit()
  // {
  //   this.submitted = true;
  //   if(this.Registrationform.invalid){
  //     return;
  //   }
    
  // }

  countStar(star:any){
    console.log(star)
  }
  addAppointment()
  {
    let id = localStorage.getItem("Id");
    this.newAppointment.userId = id;
    this.appointmentService.addAppointments(this.newAppointment).subscribe(
      (response)=>{
        console.log(response);
        this.router.navigate([""]);
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
    // this.doctorService.getRating(this.newAppointment.doctorId).subscribe(
    //   (response)=>{
    //     this.rating=response;
    //     this.stars.length = this.rating
    //     console.log(this.stars.length);
    //   },
    //   (error)=>{
    //     console.log(error);
    //   }
    // )
  }

  onTimeSelect(e:any)
  {
    console.log(e.target.value);
    this.newAppointment.appointmentTimes = e.target.value;
  }

}
