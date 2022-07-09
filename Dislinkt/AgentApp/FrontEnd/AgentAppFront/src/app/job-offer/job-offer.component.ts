import { Component, OnInit } from '@angular/core';
import { JobOffersService } from '../services/job-offers.service';

@Component({
  selector: 'app-job-offer',
  templateUrl: './job-offer.component.html',
  styleUrls: ['./job-offer.component.css']
})
export class JobOfferComponent implements OnInit {
  Job : String = "";
  Company : String = "";
  Description : String = "";
  Requirements : String = "";

  constructor(private _jobOfferService: JobOffersService) { }

  ngOnInit(): void {
  }

  Create(){
    var jobOffer = {
      job: this.Job,
      companyName: this.Company,
      description: this.Description,
      requirements: this.Requirements
    }
    this._jobOfferService.PostOffer(jobOffer).subscribe(res => console.log(res))
    
  }

}
