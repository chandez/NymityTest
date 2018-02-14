import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AuthService } from './service/auth.service';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private auth: AuthService, private router: Router) { }

    // canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    //     console.log("CanActive");
    //     if (this.auth.login()) {
    //         return true;
    //     } else {
    //         window.alert("You don't have permission to view this page");
    //         //this.router.navigate(['/home'])
    //         return false;
    //     }
    // }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        console.log("CanActive");
        if (localStorage.getItem('currentUser')) {
            return true;
        }
        this.router.navigate(['/home'], { queryParams: { returnUrl: state.url }});
        return false;
    }

    // canActivate(
    //     next: ActivatedRouteSnapshot,
    //     state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    //     return true;
    // }
}
