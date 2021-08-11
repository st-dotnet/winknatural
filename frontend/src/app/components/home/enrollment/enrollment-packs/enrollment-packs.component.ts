import { Component, OnInit } from '@angular/core';
import { SessionService } from '@app/_services';

@Component({
  selector: 'app-enrollment-packs',
  templateUrl: './enrollment-packs.component.html',
  styleUrls: ['./enrollment-packs.component.css']
})
export class EnrollmentPacksComponent implements OnInit {

  constructor(private sessionService: SessionService,) {
    this.sessionService.scrollToTop();
  }

  ngOnInit(): void {
  }

}
