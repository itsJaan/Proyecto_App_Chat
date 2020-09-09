import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { ChannelsComponent } from './channels/channels.component';
import { ChatChannelComponent } from './chat-channel/chat-channel.component';
import { MembersChannelComponent } from './members-channel/members-channel.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [DashboardComponent, ChannelsComponent, ChatChannelComponent, MembersChannelComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    FormsModule
  ]
})
export class DashboardModule { }
