import { Patient } from './../Models/patient';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private httpClient:HttpClient) { }

  BaseUrl="https://localhost:44346/api/Patient/"

  getPatients():Observable<any>
  {
    return this.httpClient.get<any>(this.BaseUrl);
  }

  postPatient(newPatient:Patient):Observable<Patient>
  {
    return this.httpClient.post<Patient>(this.BaseUrl,newPatient)
  }
}
