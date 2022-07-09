import { Component, OnInit } from '@angular/core';
import { UserServiceService } from '../services/user-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  Name : String = "";
  Surname : String = "";
  Username : String = "";
  Password : String = "";
  Email : String = "";

  constructor(private _userService: UserServiceService) { }

  ngOnInit(): void {
  }

  Register(){
    var user = {
      firstname: this.Name,
      surname: this.Surname,
      username: this.Username,
      password: this.Password,
      email: this.Email
    }

    this._userService.Register(user).subscribe(res =>
      {
        console.log(res.toString());
      },(error) => console.log(error.error));

  }

}
