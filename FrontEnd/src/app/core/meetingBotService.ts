import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Channel } from '../shared/channel';
import { catchError } from 'rxjs/operators';
import { Message } from '../shared/message';


@Injectable({
    providedIn: 'root'
  })

  export class MeetingBotService {
  
    baseUrl: string = "https://localhost:44300/api/meetingbot";
  
    constructor(private httpClient : HttpClient) { }

    getMessage(message: string, channelName: string): Observable<string[]>{
        return this.httpClient.get<string[]>(`${this.baseUrl}/${message},${channelName}`)
        .pipe(
        catchError(this.handleError)
        );
    }

    private handleError(error : any){
        console.error('server error:', error);
        if(error.error instanceof Error){
        const errorMessage = error.error.message;
        return Observable.throw(errorMessage);
        }

        return Observable.throw(error || 'Server error');
    }
}