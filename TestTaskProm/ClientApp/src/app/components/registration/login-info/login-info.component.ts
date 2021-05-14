import { RegistrationService } from './../../../services/registration.service';
import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ValidationErrors,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

export const passwordValidator: ValidatorFn = (
  control: AbstractControl
): ValidationErrors | null => {
  const validPassword =
    control?.value.search(/\d/) >= 0 && control?.value.search(/[a-zA-Z]/) >= 0;
  return !validPassword ? { passwordNotValid: true } : null;
};

export const passwordMatchValidator: ValidatorFn = (
  control: AbstractControl
): ValidationErrors | null => {
  const password = control.get('password');
  const confirmPassword = control.get('confirmPassword');

  const hasError = password?.value !== confirmPassword?.value;
  const notMatchError = { passwordNotMatch: true };
  if (hasError) {
    confirmPassword?.setErrors(notMatchError);
  }

  return null;
};

@Component({
  selector: 'app-login-info',
  templateUrl: './login-info.component.html',
  styleUrls: ['./login-info.component.scss'],
})
export class LoginInfoComponent {
  public hidePassword: boolean = true;
  public hideConfirmPassword: boolean = true;
  public form: FormGroup = new FormGroup(
    {
      login: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(2),
        passwordValidator,
      ]),
      confirmPassword: new FormControl('', [
        Validators.required,
        Validators.minLength(2),
      ]),
      agreement: new FormControl('', Validators.requiredTrue),
    },
    passwordMatchValidator
  );

  constructor(
    private registrationService: RegistrationService,
    private router: Router
  ) {}

  public submit(): void {
    if (!this.form.valid) {
      return;
    }

    this.registrationService.fillLoginInfo(
      this.form.controls.login.value,
      this.form.controls.password.value
    );
    this.router.navigate(['/registration/address']);
  }
}
