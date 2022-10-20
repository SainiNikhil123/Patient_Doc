import { Patient } from './../Models/patient';
import { PatientService } from './../Services/patient.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})
export class PatientComponent implements OnInit {

  PatientList:Patient[]=[];

  constructor(private patientService:PatientService) { }

  ngOnInit(): void {
    this.getAllPatient();
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

}
