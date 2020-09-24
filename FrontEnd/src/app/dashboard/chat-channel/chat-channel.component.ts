import { Component, OnInit, Input } from '@angular/core';
import { Channel } from 'src/app/shared/channel';
import { Message } from 'src/app/shared/message';
import { MessageService } from 'src/app/core/messageService';
import { MeetingBotService } from 'src/app/core/meetingBotService';
import { TrelloBotService } from 'src/app/core/trelloBotService';
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
  resultM: string[];
  resultT: string;
  @Input() channelSelected : Channel;
  @Input() userLogged: string;
  @Input()  messages : Message[];
   

  constructor(private messageService: MessageService,private meetingBotService: MeetingBotService, private trelloBotService : TrelloBotService, private router: Router) {
  }
  ngOnInit(): void { 
    this.messageText="";
  }
  
  onSubmit(form) {
    let dateTime: Date = new Date();
    this.resultM = [];
    this.resultT=" ";
    if (this.messageText) {
      let p = this.messageText.indexOf("/meetingbot")
      if (p != -1) {
        let messageR = this.messageText.replace('/meetingbot', '')
        this.meetingBotService.getMessage(messageR, this.channelSelected.name)
          .subscribe(
            (str: string[]) => this.resultM = str
          );
        this.updateMessages_F();
      }
      p = this.messageText.indexOf("/trellobot")
      if(p!= -1){
        let messageR = this.messageText.replace('/trellobot', '')
        this.trelloBotService.getTrelloResponse(messageR)
          .subscribe(
            (str: string) => this.resultT = str
          );
        /*this.messageService.addMessage({
          message: new String(this.resultM),
          user: "TrelloBot",
          channelName: this.channelSelected.name,
          dateTime : dateTime
        }).subscribe((data: any) => this.router.navigate(['/dashboard', this.userLogged]));*/
        this.updateMessages_F();
      }
      this.messageService.addMessage({
        message: new String(this.messageText),
        user: this.userLogged,
        channelName: this.channelSelected.name,
        dateTime: dateTime
      }).subscribe((data: any) => this.router.navigate(['/dashboard', this.userLogged]));
      form.reset()
      this.updateMessages_F();
    }
    this.updateMessages_F();
  }
  updateMessages_F() {
    this.messageService.getMessages(this.channelSelected.name)
      .subscribe(
        (messages: Message[]) => this.messages = messages
      )
  }
}