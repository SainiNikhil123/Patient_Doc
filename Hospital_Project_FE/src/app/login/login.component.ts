import { UserService } from './../Services/user.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from '../Models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  Login:Login=new Login();
  Token:string="";
  Role:string="";
  invalidLogin:boolean=false;
  

  constructor(private UserService: UserService,private router: Router) { }

  ngOnInit(): void {
  }

  loginClick()
  {
    //debugger;
    this.UserService.loginUser(this.Login).subscribe(      
      (response)=>{
         this.Token=(<any>response).token;
         let tokenData = this.Token.split('.')[1]
         let decodeJsonData = window.atob(tokenData)
         let decodeTokenData = JSON.parse(decodeJsonData)
         this.Role = decodeTokenData.role;
         let Id = decodeTokenData.Id;
        //  let EditRole = decodeTokenData.EditRole;
        //  let DeleteRole = decodeTokenData.DeleteRole;
        //  let AddRole = decodeTokenData.AddRole;
        //  localStorage.setItem("DeleteRole",DeleteRole);
        //  localStorage.setItem("EditRole",EditRole);
        //  localStorage.setItem("AddRole",AddRole);
        localStorage.setItem("Id",Id);
         localStorage.setItem("role",this.Role);
         localStorage.setItem("jwt",this.Token);
         this.router.navigate([""]);
         //console.log(response);
         //console.log(decodeTokenData);
      },
      (error)=>{
        this.invalidLogin = true;
        console.log(error);  
      }
    )
  }

  RegClick()
  {
    this.router.navigate(['register']) 
  }

}
