import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthIntercepterService implements HttpInterceptor {

  constructor() { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var token = localStorage.getItem("jwt");
    let jwtToken = req.clone({
      setHeaders:{       
        Authorization:"Bearer "+ token
      }
    })
    return next.handle(jwtToken);
  }
}
