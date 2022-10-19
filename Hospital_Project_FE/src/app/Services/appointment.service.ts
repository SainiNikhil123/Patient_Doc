import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  BaseUrl:string = "https://localhost:44346/api/Appointment/";

  constructor(private httpClient :HttpClient) { }

  getAllAppointments():Observable<any>
  {
    return this.httpClient.get<any>(this.BaseUrl);
  }

  getAppointmentById(id:any):Observable<any>
  {
    return this.httpClient.get<any>(this.BaseUrl+ "user/" + id)
  }
}
