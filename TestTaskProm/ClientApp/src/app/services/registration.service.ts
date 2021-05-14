import { LoginInfoModel } from './../models/registration/login-info.model';
import { RegistrationState } from '../enums/registration-state.enum';
import { Injectable } from '@angular/core';

@Injectable()
export class RegistrationService {
  private currentRegistrationState: RegistrationState = RegistrationState.Empty;
  private loginInfo: LoginInfoModel = {} as LoginInfoModel;

  constructor() {}

  public register(): void {
    this.currentRegistrationState = RegistrationState.Registered;
  }

  public isRegistered(): boolean {
    return this.currentRegistrationState === RegistrationState.Registered;
  }

  public isLoginInfoFilled(): boolean {
    return this.currentRegistrationState === RegistrationState.LoginInfoFilled;
  }

  public fillLoginInfo(login: string, password: string): void {
    this.loginInfo = new LoginInfoModel(login, password);
    this.currentRegistrationState = RegistrationState.LoginInfoFilled;
  }

  public fillAddress(countryId: number, provinceId: number): void {
    this.loginInfo.countryId = countryId;
    this.loginInfo.provinceId = provinceId;
    this.currentRegistrationState = RegistrationState.AddressFilled;
  }

  public getLoginInfo(): LoginInfoModel {
    return this.loginInfo;
  }
}
