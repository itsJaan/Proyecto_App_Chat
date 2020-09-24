import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Channel } from '../shared/channel';
import { catchError } from 'rxjs/operators';
import { Message } from '../shared/message';


@Injectable({
    providedIn: 'root'
  })

  export class TrelloBotService {
  
    baseUrl: string = "https://localhost:44300/api/trellobot";
  
    constructor(private httpClient : HttpClient) { }

    getTrelloResponse(message: string): Observable<string>{
        return this.httpClient.get<string>(`${this.baseUrl}/${message}`)
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