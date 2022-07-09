import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommentsComponent } from './comments/comments.component';
import { CompaniesComponent } from './companies/companies.component';
import { EditCompanyComponent } from './edit-company/edit-company.component';
import { JobOfferComponent } from './job-offer/job-offer.component';
import { JobsComponent } from './jobs/jobs.component';
import { LoginComponent } from './login/login.component';
import { RegisterCompanyComponent } from './register-company/register-company.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {path: 'register', component: RegisterComponent},
  {path: 'companies', component: CompaniesComponent},
  {path: 'companies/register-company', component: RegisterCompanyComponent},
  {path: 'job-offer', component: JobOfferComponent},
  {path: 'companies/comments/:id', component: CommentsComponent},
  {path: 'companies/edit/:id', component: EditCompanyComponent},
  {path: 'login', component: LoginComponent},
  {path: 'login/register', component: RegisterComponent},
  {path: 'companies/jobs/:id', component: JobsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
