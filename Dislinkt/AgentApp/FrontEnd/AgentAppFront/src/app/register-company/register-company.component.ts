import { Component, OnInit } from '@angular/core';

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

  constructor() { }

  ngOnInit(): void {
  }

  Register(){

  }

}
