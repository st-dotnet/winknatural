import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { BsDatepickerModule, DatepickerModule } from 'ngx-bootstrap/datepicker';
import {TextMaskModule} from 'angular2-text-mask';

@NgModule({
  declarations: [
    SignInComponent,
    SignUpComponent,],
  imports: [
    CommonModule,
    AuthRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    BsDatepickerModule.forRoot(),
    TextMaskModule,
    DatepickerModule.forRoot(),
  ]
})
export class AuthModule {
 }
