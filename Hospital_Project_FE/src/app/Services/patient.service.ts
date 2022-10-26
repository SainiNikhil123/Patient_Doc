import { Comment } from './../Models/comment';
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

  getComments(id:number):Observable<any>
  {
    return this.httpClient.get<any>(this.BaseUrl+"comment/"+id)
  }

  addComments(newComment:Comment):Observable<Comment>
  {
    return this.httpClient.post<Comment>(this.BaseUrl+"comment/",newComment)
  }

  getPatientByUserId(id:any):Observable<any>
  {
    return this.httpClient.get<any>(this.BaseUrl+"Id?Id="+id)
  }

  postRefer(id:number,docId:number):Observable<any>
  {
    return this.httpClient.post<any>(this.BaseUrl+"refer?id=",id+"&docId="+docId);
  }
}
