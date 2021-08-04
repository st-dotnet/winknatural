import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { AboutComponent } from './about/about.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EnrollmentPacksComponent } from './enrollment/enrollment-packs/enrollment-packs.component';
import { EnrollmentInfoComponent } from './enrollment/enrollment-info/enrollment-info.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TextMaskModule } from 'angular2-text-mask';


@NgModule({
  declarations: [
    HomeComponent,
    AboutComponent,
    EnrollmentPacksComponent,
    EnrollmentInfoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NgbModule,

    ReactiveFormsModule,
    HomeRoutingModule,
    TextMaskModule,
    CarouselModule]
})
export class HomeModule { }
