import { LoginInfoModel } from './../models/registration/login-info.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListItem } from '../interfaces/list-item.interface';

@Injectable()
export class HttpProxyService {
  private addressApi = '/v1/country';
  private authApi = '/v1/auth';
  constructor(public http: HttpClient) {}

  public getCountries(): Observable<ListItem[]> {
    return this.http.get<ListItem[]>(`${this.addressApi}`);
  }

  public getProvinces(countryId: number): Observable<ListItem[]> {
    return this.http.get<ListItem[]>(
      `${this.addressApi}/${countryId}/province`
    );
  }

  public registerUser(userInfo: LoginInfoModel): Observable<any> {
    return this.http.post(`${this.authApi}`, userInfo);
  }
}
