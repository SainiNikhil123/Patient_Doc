import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  BaseUrl:string = "https://localhost:44346/api/User/";

  constructor(private httpClient :HttpClient) { }

  getUser():Observable<any>
  {
    return this.httpClient.get<any>(this.BaseUrl);
  }

  registerUser(reg:User):Observable<User>
  {
    return this.httpClient.post<User>(this.BaseUrl +"Register",reg);
  }

  loginUser(login:any):Observable<any>
  {
    return this.httpClient.post<any>(this.BaseUrl+"Authenticate",login);
  }

}
