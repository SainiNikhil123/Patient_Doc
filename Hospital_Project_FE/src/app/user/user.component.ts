import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { User } from '../Models/user';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  UserList:User[]=[];

  constructor(private service:UserService, private router:Router) { }

  ngOnInit(): void {
    this.GetAllUser();
  }

  GetAllUser()
  {
    debugger;
    this.service.getUser().subscribe(
      (response)=>{
        this.UserList= response;
        console.log(this.UserList)
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  onClick()
  {
    this.router.navigate(['register']) 
  }

}
