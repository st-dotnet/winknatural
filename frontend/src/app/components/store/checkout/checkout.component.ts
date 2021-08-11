import { Component, OnInit } from '@angular/core';
import { NgbPanelChangeEvent } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  // isSecondPanelDisable=false;
  // isThirdPanelDisable=false;
  // isActive=false;

  constructor() { }

  ngOnInit(): void {
  }

  // changeTitle($event: NgbPanelChangeEvent, acc) {

  //   if (!acc.isExpanded($event.panelId)) {
  //     this.isActive = true;
  //   } else {
  //     this.isActive = false;
  //   }
  //   alert(this.isActive);
  // }

}
