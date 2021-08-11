import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  title = 'ng-bootstrap-modal-demo';
  closeResult: string;
  modalOptions: NgbModalOptions = {
    backdrop: 'static',
    backdropClass: 'customBackdrop'
  };
  
  // isSecondPanelDisable=false;
  // isThirdPanelDisable=false;
  // isActive=false;

  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  open(content) {
    this.modalService.open(content, this.modalOptions).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
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
