export class LoginInfoModel {
  public login: string;
  public password: string;
  public countryId?: number;
  public provinceId?: number;

  constructor(login: string, password: string) {
    this.login = login;
    this.password = password;
  }
}
