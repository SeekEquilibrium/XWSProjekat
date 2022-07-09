import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommentsService } from '../services/comments.service';
import { UserServiceService } from '../services/user-service.service';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {
  Comments : any[] = [];
  Company : String = "";
  Comment: String = "";
  User : any;

  constructor(private _route: ActivatedRoute, private _commentsService: CommentsService, private _userService: UserServiceService) { }

  ngOnInit(): void {
    this.Company = String(this._route.snapshot.paramMap.get('id'));
    this._commentsService.GetComments(this.Company).subscribe(comments =>this.Comments = comments);
    this.User = this._userService.GetUser();
  }

  Post(){
    var comm = {
      companyId: this.Company,
      userId: this.User.id,
      username: this.User.username,
      text: this.Comment
    }
    this._commentsService.PostComment(comm).subscribe(res => window.location.reload());
  }

}
