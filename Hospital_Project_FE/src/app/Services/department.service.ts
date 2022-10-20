import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private HttpClient:HttpClient) { }

  BaseUrl="https://localhost:44346/api/Department/";

  getAllDepartment():Observable<any>
  {
    return this.HttpClient.get<any>(this.BaseUrl);
  }
}
