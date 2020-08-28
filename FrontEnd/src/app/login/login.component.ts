import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../shared/user';
import { UserService } from '../core/userService';
import { ChannelService } from '../core/channelService';
import { FormControl, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  users: User[];
  constructor(private userService : UserService) { }
  ngOnInit(): void {
    this.userService.getUsers()
      .subscribe(
        (users : User[]) => this.users = users
      )
  }
}
