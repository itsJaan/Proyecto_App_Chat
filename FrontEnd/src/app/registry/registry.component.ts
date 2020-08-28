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
  encontrado :boolean;
  form: FormGroup;
  constructor(private userService : UserService , private router: Router) { 
  }

  ngOnInit(): void {    
    this.form = this.createForm();
    this.userService.getUsers()
      .subscribe(
        (users : User[]) => this.users = users
      )
  }
  createForm() : FormGroup{
    return new FormGroup({
      username: new FormControl("", Validators.required),
      name: new FormControl("", Validators.required),
      password: new FormControl("", Validators.required)
    });
  }
  get element(){
    return JSON.stringify(this.user);
  }
  onSubmit(){
    //this.encontrado=false;
    const user = this.form.value;
    //this.users.forEach((element : User)=> {
      //if(this.user.username == element.username)
        //return this.encontrado=true;
    //});
    //if(!this.encontrado){
      this.userService.addUser({
        username:user.username,
        name:user.name,
        password:user.password 
      })
      .subscribe((data : any) => this.router.navigate(['/login']));
    //}else{
      //return window.confirm('Usuario Existente');
    //}
  }
  
}
