import { RegisterComponent } from './../register/register.component';
import { Patient } from './../Models/patient';
import { PatientService } from './../Services/patient.service';
import { Component, OnInit } from '@angular/core';
import {Comment} from './../Models/comment';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})
export class PatientComponent implements OnInit {

  PatientList:Patient[]=[];
  comments:any[]=[]
  newComments:Comment = new Comment();

  constructor(private patientService:PatientService) { }

  ngOnInit(): void {
    this.getAllPatient();
    //this.commentClick(0);
  }

  getAllPatient()
  {
    this.patientService.getPatients().subscribe(
      (response)=>{
        this.PatientList = response;
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

}
