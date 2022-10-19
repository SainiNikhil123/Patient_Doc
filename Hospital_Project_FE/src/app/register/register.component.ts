import { RolesService } from './../Services/roles.service';
import { Roles } from './../Models/roles';
import { UserService } from './../Services/user.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../Models/user';
import Swal from 'sweetalert2'
import { retry } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  newReg:User = new User();
  RoleList:Roles[]=[];
  selectedRole:string="";

  constructor(private UserService: UserService,private RoleService:RolesService, private route:Router) { }

  ngOnInit(): void {
    this.getAllRole();
  }

  Register()
  {
    this.newReg.id = "";
    this.newReg.roleId = this.selectedRole;
    if(this.newReg.roleId == "")
    {
      this.newReg.roleId ="21e59532-c588-4113-90d5-b46aeda68084"
    }    
    //this.newReg.role = null;
    this.UserService.registerUser(this.newReg).subscribe(
      (response)=>{
        console.log(response);
        this.route.navigate([""]);
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'You are Sucessfully Registered',
          showConfirmButton: false,
          timer: 1500
        })        
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getAllRole()
  { 
    this.RoleService.getRoles().subscribe(
      (response)=>{
        this.RoleList = response;
        console.log(this.RoleList);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  Dropdown(e:any)
  {
     console.log(e);
     this.selectedRole = e.target.value;
  }

  AdminRole()
  {
    var Role = localStorage.getItem("role")
    if(Role == "Admin") return true;
    return false;
  }
}
