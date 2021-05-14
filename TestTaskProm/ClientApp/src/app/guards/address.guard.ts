import { RegistrationService } from './../services/registration.service';
import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
} from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AddressGuard implements CanActivate {
  constructor(
    private router: Router,
    private registrationService: RegistrationService
  ) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    if (this.registrationService.isLoginInfoFilled()) {
      return true;
    }

    this.router.navigate(['/registration/login-info']);
    return false;
  }
}
