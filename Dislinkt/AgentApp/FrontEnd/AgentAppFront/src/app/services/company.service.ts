import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  
  private _APIUrl = "https://localhost:7209/";

  constructor(private _httpClient: HttpClient) { }

  Register(val : any){
    return this._httpClient.post(this._APIUrl +'companies/register',val);
  }

  GetCompanies(){
    return this._httpClient.get<any[]>(this._APIUrl +'companies')
  }

  GetCompany(id: any){
    return this._httpClient.get<any>(this._APIUrl + `companies/${id}`)
  }

  Confirm(id: number){
    return this._httpClient.get<any>(this._APIUrl + `companies/confirm/${id}`)
  }

  Update(val : any){
    return this._httpClient.post(this._APIUrl +'companies/update',val);
  }

  PostJobOffer(val : any){
    return this._httpClient.post(this._APIUrl +'companies/jobOffer',val);
  }
}
