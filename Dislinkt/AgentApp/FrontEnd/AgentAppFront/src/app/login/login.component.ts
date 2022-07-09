import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from '../services/user-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  Username : String = "";
  Password : String = "";

  constructor(private _userService: UserServiceService, private _router: Router) { }

  ngOnInit(): void {
  }
  
  Login(){
    var login = {
      username : this.Username,
      password : this.Password
    }
    this._userService.Login(login).subscribe(res => this._router.navigate(["/companies"]), err => console.log(err.error));
  }

}
