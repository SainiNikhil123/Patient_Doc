import { Router } from '@angular/router';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Hospital_Project_FE';

  UserName:any="";
  receptionRole:boolean=false;
  doctorRole:boolean=false;
  adminRole:boolean = false;

  constructor(private router:Router) {}

  ngOnInit(): void {
    this.UserName;
    
  }

  ngDoCheck():void{

    this.MenuDisplay();

  }

  Logout()
{
  localStorage.removeItem("jwt");
  localStorage.removeItem("Id");
  localStorage.removeItem("role");
  this.router.navigate(['']);
}

isAuthorized()
{
  const token= localStorage.getItem("jwt");
  
    if(token)
    {
      let tokenData = token.split('.')[1]
      let decodeJsonData = window.atob(tokenData)
      let decodeTokenData = JSON.parse(decodeJsonData)
      this.UserName = decodeTokenData.unique_name;
      return true;
    }
    else
    { 
      return false;
    }  
}

MenuDisplay()
{
 let role = localStorage.getItem("role")
 this.adminRole = (role == "Admin");
 this.doctorRole = (role == "Doctor");
 this.receptionRole = (role == "Reception")
}

}
