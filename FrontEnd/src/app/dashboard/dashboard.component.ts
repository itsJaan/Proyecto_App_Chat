import { Component, OnInit } from '@angular/core';
import { UserService } from '../core/userService';
import { ChannelService } from '../core/channelService';
import { Channel } from '../shared/channel';
import { LoginRoutingModule } from '../login/login-routing.module';
import { ActivatedRoute} from '@angular/router';
import { Router } from '@angular/router';
import { Message } from '../shared/message';
import { MessageService } from '../core/messageService';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  
  channels : Channel[];
  messages : Message[];
  userLogged: String;
  channelSelected : Channel;
  constructor(private channelService : ChannelService, private messageService : MessageService , private router: Router, private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.userLogged = this.activeRoute.snapshot.params.username
    this.channelService.getChannels()
      .subscribe(
        (channels : Channel[]) => this.channels = channels
      )
  }
  element(){
    return JSON.stringify(this.userLogged);
  }
  showChannel(channel : Channel){
    this.channelSelected = channel;
    this.messageService.getMessages(channel.name)
    .subscribe(
      (messages : Message[]) => this.messages = messages
    )
  }
  logout(){
    this.userLogged = ""
    this.router.navigate(['/login']);
  }
}
