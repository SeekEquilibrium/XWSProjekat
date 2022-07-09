import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private _APIUrl = "https://localhost:7209/";

  constructor(private _httpClient: HttpClient) { }

  PostJob(val: any){
    return this._httpClient.post(this._APIUrl +'jobs',val)
  }

  GetByCompany(id: any){
    return this._httpClient.get<any[]>(this._APIUrl + `jobs/byCompany/${id}`)
  }  
}
