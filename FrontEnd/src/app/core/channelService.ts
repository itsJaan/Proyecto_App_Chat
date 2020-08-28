import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Channel } from '../shared/channel';
import { catchError } from 'rxjs/operators';


@Injectable({
    providedIn: 'root'
  })

  export class ChannelService {
  
    baseUrl: string = "https://localhost:44300/api/Channels";
  
    constructor(private httpClient : HttpClient) { }

    getChannels(): Observable<Channel[]>{
        return this.httpClient.get<Channel[]>(this.baseUrl)
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