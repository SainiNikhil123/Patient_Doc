import { PatientService } from './../Services/patient.service';
import { Patient } from './../Models/patient';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-my-records',
  templateUrl: './my-records.component.html',
  styleUrls: ['./my-records.component.scss']
})
export class MyRecordsComponent implements OnInit {

  MYPatientList:Patient[]=[];
  comments:any[]=[];

  constructor(private service:PatientService, private patientService:PatientService) { }

  ngOnInit(): void {
    this.getPatients();
  }

  getPatients()
  {
    var id = localStorage.getItem("Id");
    this.service.getPatientByUserId(id).subscribe(
      (response)=>{
        this.MYPatientList = response;
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

}
