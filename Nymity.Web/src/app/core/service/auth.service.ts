import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {

  constructor(private router: Router) { }

    signOut(): void {
        this.router.navigate(['/']);
    }

    login(): boolean {
        console.log("login");
        return false;
    }

}
