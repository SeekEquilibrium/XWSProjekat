import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CompaniesComponent } from './companies/companies.component';
import { RegisterComponent } from './register/register.component';
import { RegisterCompanyComponent } from './register-company/register-company.component';
import { UpdateCompanyComponent } from './update-company/update-company.component';
import { JobsComponent } from './jobs/jobs.component';
import { CommentsComponent } from './comments/comments.component';
import { HttpClientModule } from '@angular/common/http';
import { JobOfferComponent } from './job-offer/job-offer.component';
import { EditCompanyComponent } from './edit-company/edit-company.component';
import { LoginComponent } from './login/login.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CompaniesComponent,
    RegisterComponent,
    RegisterCompanyComponent,
    UpdateCompanyComponent,
    JobsComponent,
    CommentsComponent,
    JobOfferComponent,
    EditCompanyComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
