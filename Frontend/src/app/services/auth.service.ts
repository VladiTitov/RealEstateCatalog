import { Injectable } from '@angular/core';
import { IUser } from '../model/IUser.Interface';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

constructor() { }

authUser(user: any) {
  let UserArray = new Array<IUser>;
  if (localStorage.getItem('Users')) {
    UserArray = JSON.parse(localStorage.getItem('Users')!);
  }
  return UserArray.find(i => i.userName === user.userName && i.password === user.password);
}

}
