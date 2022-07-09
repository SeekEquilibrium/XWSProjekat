import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  User = {};

  private _APIUrl = "https://localhost:7209/";

  constructor(private _httpClient: HttpClient) { }

  Register(val:any){
    return this._httpClient.post(this._APIUrl +'users/register',val);
  }

  Login(val:any){
    var ret = this._httpClient.post(this._APIUrl +'users/login',val)
    ret.subscribe(res => {this.User = res; localStorage.setItem('access_token', JSON.stringify(res));})
    return ret;
  }

  GetUser(){
    return JSON.parse(localStorage.getItem('access_token') || '{}');;
  }

  Logout(){
    localStorage.removeItem('access_token');
  }
}
