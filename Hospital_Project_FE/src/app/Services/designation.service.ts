import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class DesignationService {

  constructor(private HttpClient:HttpClient) { }

  BaseUrl="https://localhost:44346/api/Designation/";

  getAllDesignation():Observable<any>
  {
    return this.HttpClient.get<any>(this.BaseUrl);
  }
}
