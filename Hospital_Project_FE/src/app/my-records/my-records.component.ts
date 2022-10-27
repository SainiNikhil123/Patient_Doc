import { PatientService } from './../Services/patient.service';
import { Patient } from './../Models/patient';
import { Component, OnInit } from '@angular/core';
import { Docrating } from '../Models/docrating';
import { DoctorService } from '../Services/doctor.service';

@Component({
  selector: 'app-my-records',
  templateUrl: './my-records.component.html',
  styleUrls: ['./my-records.component.scss']
})
export class MyRecordsComponent implements OnInit {

  MYPatientList:Patient[] = [];
  comments:any[] = [];
  rating:number = 0;
  stars:number[] = [1, 2, 3, 4, 5];
  newRating: Docrating = new Docrating();

  constructor(private service:PatientService, private patientService:PatientService, private docService:DoctorService) { }

  ngOnInit(): void {
    this.getPatients();
  }

  getPatients()
  {
    var id = localStorage.getItem("Id");
    this.service.getPatientByUserId(id).subscribe(
      (response)=>{
        this.MYPatientList = response;
        this.MYPatientList.forEach(X => {
          X.doctors.docname == null ? X.referName = "NOT REFERED" : X.referName = X.doctors.docname
          console.log(X.doctors.docname);
        });
        console.log(this.MYPatientList)
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  commentClick(e:number)
  {
    console.log(e);
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

  updateRating(i:number,patient:Patient)
  { 
    this.rating = i
    this.newRating.patientId = patient.id;
    this.newRating.doctorId = patient.doctorId;
    this.newRating.rating = this.rating
    this.docService.postNewRating(this.newRating).subscribe(
      (response)=>{
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    )
  }
}
