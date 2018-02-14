import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

import { API_URL } from '../../app.config';

@Injectable()
export class AuthService {

    constructor(private http: HttpClient, private router: Router) { }

    signOut(): void {
        this.router.navigate(['/']);
    }

    getUser() {
        // console.log('Get User.........');
        //  this.http.get<user[]>(this.config.apiUrl + '/authenticate')
        //  .map(
        //      (users) => {
        //         for(let user of users){
        //             console.log(user);
        //         }
        //         console.log(users);
        //         return users;
        //      }
        //  );
        //  console.log(user);
        //  return user;
    }

    login(email: string, password: string) {
        console.log("Call Auth....");
        return this.http.post(`${API_URL}/Authenticate`, { "email": "chan@mail.com", "password": "123456" })
            .map((user) => {
                console.log(user);
                return user;
            })
            .catch((error) => {
                return Observable.throw('Error on service authenticate.');
            });
            
        // return this.http.post(this.config.apiUrl + '/authenticate', { email: email, password: password })
        //     .map((response: Response) => {
        //         console.log(response);
        //         // login successful if there's a jwt token in the response
        //         let user = response.json();
        //         if (user && user.token) {
        //             // store user details and jwt token in local storage to keep user logged in between page refreshes
        //             localStorage.setItem('currentUser', JSON.stringify(user));
        //         }
        //     });
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
    }

}
