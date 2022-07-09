import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JobService } from '../services/job.service';
import { UserServiceService } from '../services/user-service.service';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent implements OnInit {
  Jobs: any[] = [];
  Company: String = "";
  Name: String = "";
  User: any;

  constructor(private _route: ActivatedRoute, private _jobService: JobService, private _userService: UserServiceService) { }

  ngOnInit(): void {
    this.Company = String(this._route.snapshot.paramMap.get('id'));
    this._jobService.GetByCompany(this.Company).subscribe(jobs => this.Jobs = jobs);
    this.User = this._userService.GetUser();
  }

  Post(){
    var job = {
      name: this.Name,
      companyId: this.Company
    }
    this._jobService.PostJob(job).subscribe(res => window.location.reload());
  }

}
