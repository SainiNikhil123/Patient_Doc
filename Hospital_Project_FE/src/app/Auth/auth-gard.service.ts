import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGardService implements CanActivate {

  constructor(private route:Router, private jwtHelper: JwtHelperService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const token = localStorage.getItem("jwt");

    if(token && !this.jwtHelper.isTokenExpired(token))
    {
      return true;
    }
    localStorage.removeItem("Id");
    localStorage.removeItem("role");
    localStorage.removeItem("jwt");
    //alert("Not Authorized")
    this.route.navigate(["login"]);
    return false;
  }
  
}
