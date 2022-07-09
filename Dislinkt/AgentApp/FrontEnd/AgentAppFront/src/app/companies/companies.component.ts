import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CompanyService } from '../services/company.service';
import { UserServiceService } from '../services/user-service.service';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit {
  User : any;
  Companies : any[] = [];
  Selected : String = ""

  constructor(private _companyService : CompanyService, private _router: Router, private _userService: UserServiceService) { }

  ngOnInit(): void {
    this._companyService.GetCompanies().subscribe(Companies => this.Companies = Companies);
    this.User = this._userService.GetUser();
    console.log(this.User.role)
  }

  Confirm(id: any){
    this._companyService.Confirm(id).subscribe(res => window.location.reload())
  }

  RowSelected(Company : any){
    this.Selected = Company.id;
  }

  Comments(){
    this._router.navigate(["/companies/comments/" + this.Selected])
  }

  Edit(){
    if(this.User.role == 2){
      this._router.navigate(["/companies/edit/" + this.Selected])
    }
  }

  Jobs(){
    this._router.navigate(["/companies/jobs/" + this.Selected])
  }

}
