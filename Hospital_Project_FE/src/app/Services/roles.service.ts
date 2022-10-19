import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  BaseUrl:string = "https://localhost:44346/api/Roles/";

  constructor(private httpClient :HttpClient) { }

  getRoles():Observable<any>
  {
    return this.httpClient.get<any>(this.BaseUrl);
  }
}
