import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from '../core/service/auth.service';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {

    user: User;
    subscription: Subscription;

    constructor(private auth: AuthService) { }

    ngOnInit() {
    }

    onClick() {

        this.subscription = this.subscription = this.auth.login('', '')
            .subscribe(
                (user) => this.user = user,
                (error) => console.log(error)
            );
    }

    ngOnDestroy() {
        //this.subscription.unsubscribe();
    }
}


export class User {
    id: number;
    name: string;
    email: string;
    token: string;
}