import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JobOffersService {
  private _APIUrl = "https://localhost:7209/";
  
  constructor(private _httpClient: HttpClient) { }

  PostOffer(val: any){
    return this._httpClient.post(this._APIUrl +'companies/jobOffer',val);
  }
}
