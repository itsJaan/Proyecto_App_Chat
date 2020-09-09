import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/user';
import { UserService } from 'src/app/core/userService';

@Component({
  selector: 'app-members-channel',
  templateUrl: './members-channel.component.html',
  styleUrls: ['./members-channel.component.css']
})
export class MembersChannelComponent implements OnInit {
  users : User[];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUsers()
      .subscribe(
        (users : User[]) => this.users = users
      )
  }
}
