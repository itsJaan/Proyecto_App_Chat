import { Component, OnInit, Input } from '@angular/core';
import { Channel } from 'src/app/shared/channel';
import { Message } from 'src/app/shared/message';
import { MessageService } from 'src/app/core/messageService';
import { Router } from '@angular/router';


@Component({
  selector: 'app-chat-channel',
  templateUrl: './chat-channel.component.html',
  styleUrls: ['./chat-channel.component.css']
})
export class ChatChannelComponent implements OnInit {

  messageText : string;
  private _messages: Message[] = [];
  updatedMessages: Message[];
  upp: Boolean;
  @Input() channelSelected : Channel;
  @Input() userLogged: string;
  @Input()  messages : Message[];
   

  constructor(private messageService: MessageService, private router: Router) {
  }
  ngOnInit(): void { 
    this.messageText="";
  }
  
  onSubmit(form){
    let dateTime: Date = new Date();
    if(this.messageText){
      this.messageService.addMessage({
        message: new String(this.messageText),
        user: this.userLogged, 
        channelName: this.channelSelected.name,
        dateTime: dateTime
      }).subscribe((data : any) => this.router.navigate(['/dashboard',this.userLogged]));
      form.reset()
      this.updateMessages_F();
    }
    this.updateMessages_F();
  }
  updateMessages_F(){
    this.messageService.getMessages(this.channelSelected.name)
    .subscribe(
      (messages : Message[]) => this.messages = messages
    )
  }
}