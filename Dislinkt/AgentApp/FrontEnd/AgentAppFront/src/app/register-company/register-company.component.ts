import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../services/company.service';
import { UserServiceService } from '../services/user-service.service';

@Component({
  selector: 'app-register-company',
  templateUrl: './register-company.component.html',
  styleUrls: ['./register-company.component.css']
})
export class RegisterCompanyComponent implements OnInit {
  Name:String = "";
  UserId: String = ""
  Phone:String = "";
  Email: String = "";
  Description: String = "";
  User : any;

  constructor(private _companyService: CompanyService, private _userService: UserServiceService) { }

  ngOnInit(): void {
    this.User = this._userService.GetUser();
  }

  Register(){
    var company = {
      name : this.Name,
      ownerId : this.User.id,
      email : this.Email,
      phoneNumber : this.Phone,
      description : this.Description
    }
    this._companyService.Register(company).subscribe(res => console.log(res));
  }

}
