import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Channel } from 'src/app/shared/channel';

@Component({
  selector: 'app-channels',
  templateUrl: './channels.component.html',
  styleUrls: ['./channels.component.css']
})
export class ChannelsComponent implements OnInit {

  @Input() channels : Channel[];
 
  @Output() sendChannel= new EventEmitter<Channel>();
 
  channelSelected : Channel;
  
  constructor() { }

  ngOnInit(): void {
  
  }
  showChannelChat(channel: Channel){
    this.channelSelected= channel;
    this.sendChannel.emit(this.channelSelected);
  }

}
