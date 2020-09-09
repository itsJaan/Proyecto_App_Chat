import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { User } from '../shared/user';
import { UserService } from '../core/userService';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-registry',
  templateUrl: './registry.component.html',
  styleUrls: ['./registry.component.css']
})
export class RegistryComponent implements OnInit {


  user: User;
  users : User[];
  constructor(private userService : UserService , private router: Router) { 
  }

  ngOnInit(): void {
    this.user={};   
    this.userService.getUsers()
      .subscribe(
        (users : User[]) => this.users = users
      )
  }
  get element(){
    return JSON.stringify(this.user);
  }
  onSubmit(form){
    var encontrado=false;
    for (let element of this.users){
      if(this.user.username == element.username)
        encontrado=true;
    }
    if(encontrado==false){
      this.userService.addUser({
        username:this.user.username,
        name:this.user.name,
        password:this.user.password 
      })
      .subscribe((data : any) => this.router.navigate(['/login']));
    }else{
      form.reset();
      return window.confirm('Usuario Existente');
      
    }
  }
}
