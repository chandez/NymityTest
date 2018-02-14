import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AuthService } from '../core/service/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    alertService: any;
    model: any = {};
    loading = false;
    returnUrl: string;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthService) { }

    ngOnInit() {
        // reset login status
        this.authenticationService.logout();

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    login() {
        console.log('Login....');

        console.log(this.model.email);
        console.log(this.model.password);

        this.loading = true;

        this.authenticationService.getUser();

        // this.authenticationService.login(this.model.email, this.model.password)
        //     .subscribe(
        //         data => {
        //             console.log(data);
        //             this.router.navigate([this.returnUrl]);
        //         },
        //         error => {
        //             this.alertService.error('Username or password is incorrect');
        //             this.loading = false;
        //         });
    }

}












