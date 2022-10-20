import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  constructor(private httpClient:HttpClient) { }

  BaseUrl="https://localhost:44346/api/Doctor/"

  getAllDoctors():Observable<any>
  {
    return this.httpClient.get<any>(this.BaseUrl);
  }
}
