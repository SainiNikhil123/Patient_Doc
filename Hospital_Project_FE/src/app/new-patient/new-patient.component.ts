import { NewPatient } from './../Models/new-patient';
import { DoctorService } from './../Services/doctor.service';
import { DepartmentService } from './../Services/department.service';
import { Patient } from './../Models/patient';
import { PatientService } from './../Services/patient.service';
import { Component, OnInit } from '@angular/core';
import { Doctor } from '../Models/doctor';
import { Department } from '../Models/department';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-new-patient',
  templateUrl: './new-patient.component.html',
  styleUrls: ['./new-patient.component.scss']
})
export class NewPatientComponent implements OnInit {

  newPatient:NewPatient=new NewPatient();
  AllDoctors:Doctor[]=[];
  DoctorsByDep:Doctor[]=[];
  DepartmentList:Department[]=[];
  registrationform !: FormGroup;

  constructor(private fb:FormBuilder,private patientService:PatientService, private departmentService:DepartmentService, private doctorService: DoctorService) { }

  ngOnInit(): void {
    this.getAllDep();
    this.getAllDoc();
    this.onSelectDep(0);
    this.onSelectDoc(0);
  }
  CreateForm()
  {
    this.registrationform = this.fb.group({
      name: ['', Validators.required ],
      phoneNumber: ['', Validators.required ],
      Address: ['', Validators.required ],
      // department:['', Validators.required ],
      // doctor:['', Validators.required ],
  })

  }
  AddPatient()
  {
    debugger;
    let userId = localStorage.getItem("Id");
    if(this.newPatient.appointmentId == 0)
    {
      this.newPatient.userId = userId;
    }
    this.patientService.postPatient(this.newPatient).subscribe(
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
        console.log(this.DepartmentList);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  onSelectDep(e:any)
  {
    //console.log(e.target.value);
    this.newPatient.departmentId = e.target.value;
    this.DoctorsByDep = this.AllDoctors.filter(x=>x.departmentId == e.target.value);
    console.log(this.DoctorsByDep)
  }

  onSelectDoc(e:any)
  {
    this.newPatient.doctorId = e.target.value;
  }

}
