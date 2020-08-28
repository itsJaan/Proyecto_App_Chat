import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../shared/user';
import { catchError } from 'rxjs/operators';


@Injectable({
    providedIn: 'root'
  })

  export class UserService {
  
    baseUrl: string = "https://localhost:44300/api/Users";
  
    constructor(private httpClient : HttpClient) { }

    getUsers(): Observable<User[]>{
        return this.httpClient.get<User[]>(this.baseUrl)
        .pipe(
        catchError(this.handleError)
        );
    }

    addUser(user : User){
        return this.httpClient.post(this.baseUrl, user)
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





