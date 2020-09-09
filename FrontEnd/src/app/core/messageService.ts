import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Message } from '../shared/message';
import { catchError } from 'rxjs/operators';


@Injectable({
    providedIn: 'root'
  })

  export class MessageService {
  
    baseUrl: string = "https://localhost:44300/api/message";
  
    constructor(private httpClient : HttpClient) { }

    

    getMessages(name : string) :Observable<Message[]>{
        return this.httpClient.get<Message[]>(`${this.baseUrl}/${name}`)
          .pipe(
            catchError(this.handleError)
          );
    }
    
    addMessage(message : Message){
        return this.httpClient.post(this.baseUrl, message)
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