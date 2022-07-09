import { Component, OnInit } from '@angular/core';
import { UserServiceService } from '../services/user-service.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  User: any;

  constructor(private _userService: UserServiceService) { }

  ngOnInit(): void {
    this.User = this._userService.GetUser();
  }

  Logout(){
    this._userService.Logout();
    this.User = null;
    window.location.reload()
  }

}
