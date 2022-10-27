import { DoctorService } from './../Services/doctor.service';
import { HttpClient } from '@angular/common/http';
import { RegisterComponent } from './../register/register.component';
import { Patient } from './../Models/patient';
import { PatientService } from './../Services/patient.service';
import { Component, OnInit } from '@angular/core';
import {Comment} from './../Models/comment';
import { Doctor } from '../Models/doctor';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})
export class PatientComponent implements OnInit {

  PatientList:Patient[]=[];
  AllDoctors:Doctor[]=[];
  DoctorsByDep:Doctor[]=[];
  comments:any[]=[]
  newComments:Comment = new Comment();
  patient:Patient = new Patient();

  constructor(private doctorService:DoctorService,private patientService:PatientService) { }

  ngOnInit(): void {
    this.getAllPatient();
    this.getAllDoc();
    
  }
  ngDoCheck():void{

    this.DoctorsByDep;

  }

  getAllPatient()
  {
    debugger;
    this.patientService.getPatients().subscribe(
      (response)=>{
        this.PatientList = response;
        this.PatientList.forEach(X => {
          X.doctors.docname == null ? X.referName = "NOT REFERED" : X.referName = X.doctors.docname
          console.log(X.doctors.docname);
        });
        
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  commentClick(e:number)
  {
    console.log(e);
    this.newComments.patientId = e;
    this.patientService.getComments(e).subscribe(
      (response)=>{
        this.comments = response;
        console.log(this.comments);
      },
      (error)=>{
        console.log(error);
      }
    )

  }

  AddComment()
  {
    this.patientService.addComments(this.newComments).subscribe(
      (response)=>{
        this.commentClick(this.newComments.patientId);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  role :any = localStorage.getItem("role")
  doctorRole()
{
  if(this.role == "Doctor") return true;
  return false;
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


referClick(e:any)
{
  debugger;
  this.patient = e;
  this.DoctorsByDep = this.AllDoctors.filter(x=>x.departmentId == this.patient.departmentId && x.designationId == 3);
  console.log(this.DoctorsByDep);
}

onSelectDoc(e:any)
{
  this.patient.doctorId = e.target.value;
  console.log(this.patient.doctorId);
  
}

onSubmit()
{
  this.patientService.postRefer(this.patient.id,this.patient.doctorId).subscribe(
    (response)=>{
      console.log(response);
    },
    (error)=>{
      console.log(error);
    }
  )
}
}
