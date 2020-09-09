import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../shared/user';
import { UserService } from '../core/userService';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  users: User[];
  user : User;
  userLogged : String;
  constructor(private userService : UserService, private router: Router) { }


  ngOnInit(): void {
    this.user={};
    this.userService.getUsers()
      .subscribe(
        (users : User[]) => this.users = users
      )
  }
  onSubmit(form){
    var encontrado=false;
    for (let element of this.users){
      if(this.user.username == element.username && this.user.password == element.password){encontrado=true;}
    }
    if(encontrado==true){
      this.userLogged = this.user.username;
      this.router.navigate(['/dashboard' , this.userLogged]);
    }else{
      form.reset();
      return window.confirm('Usuario y/o contraseña inválidos');
      
    }
  }
}