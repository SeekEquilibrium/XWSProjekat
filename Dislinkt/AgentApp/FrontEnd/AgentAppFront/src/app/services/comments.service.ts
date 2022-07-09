import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  private _APIUrl = "https://localhost:7209/";

  constructor(private _httpClient: HttpClient) { }

  GetComments(id : any){
    return this._httpClient.get<any[]>(this._APIUrl +`comments/company/${id}`);
  }

  PostComment(val : any){
    return this._httpClient.post(this._APIUrl +'comments',val)
  }

}
