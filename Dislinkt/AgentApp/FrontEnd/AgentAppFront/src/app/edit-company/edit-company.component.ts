import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CompanyService } from '../services/company.service';

@Component({
  selector: 'app-edit-company',
  templateUrl: './edit-company.component.html',
  styleUrls: ['./edit-company.component.css']
})
export class EditCompanyComponent implements OnInit {
  Id : String = "";
  Company : any;

  constructor(private _route: ActivatedRoute, private _companyService: CompanyService) { }

  ngOnInit(): void {
    this.Id = String(this._route.snapshot.paramMap.get('id'));
    this._companyService.GetCompany(this.Id).subscribe(company => this.Company = company);
  }

  Update(){
    this._companyService.Update(this.Company).subscribe(res => console.log(res))
  }

}
