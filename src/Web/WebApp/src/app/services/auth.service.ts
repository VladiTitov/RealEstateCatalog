import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUserForLogin, IUserForRegister} from '../model/IUser';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  authUser(user: IUserForLogin) {
    return this.http.post<IUserForLogin>(this.baseUrl + '/account/login', user);
  }

  registerUser(user: IUserForRegister) {
    return this.http.post<IUserForRegister>(this.baseUrl + "/account/register", user);
  }
}
