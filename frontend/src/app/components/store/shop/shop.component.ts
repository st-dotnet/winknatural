import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap'
import { SessionService } from '@app/_services';
import { ShopService } from '@app/_services/shop.service';
import { CategoryModel, ShopProductModel } from '@app/_models/shop';
import { NgxSpinnerService } from 'ngx-spinner';
import { environment } from '@environments/environment';
import { Router } from '@angular/router';


@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  title = '';
  closeResult: string;
  webCategoryID: number = 3;
  categoryModels: CategoryModel[] = [];
  shopProductModels: ShopProductModel[] = [];
  categoryId: number = 0;
  modalOptions: NgbModalOptions = {
    backdrop: 'static',
    backdropClass: 'customBackdrop',
    windowClass: 'prodview-modal'
  };

  constructor(
    private sessionService: SessionService,
    private modalService: NgbModal, private shopService: ShopService
    ,private spinner:NgxSpinnerService,private router:Router ) {
    this.sessionService.scrollToTop();
  }

  ngOnInit(): void {
    this.GetDDLCategoryById();

  }

  GetDDLCategoryById() {
    this.shopService.GetCategoryForShopById(this.webCategoryID).subscribe(result => {
      this.categoryModels = result;
      var data = this.categoryModels.filter(x => x.webCategoryDescription.toString() === "All Products");
      this.categoryId = data[0]?.webCategoryID;
      this.GetProductsList(this.categoryId);
      console.log(this.categoryId);
    })
  }
  onCategoryChange(e: Event) {
    this.categoryId = 0;
    this.categoryId = Number((e.target as HTMLInputElement)?.value);
    this.GetProductsList(this.categoryId);
    console.log(this.categoryId);
  }



  open(content: any) {
    debugger
    //this.router.navigate(['/product', { id: content }]);
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

  GetProductsList(categoryID: number) {
    this.spinner.show();
    this.shopService.GetProductsList(categoryID).subscribe(result => {
      this.shopProductModels = result;
      // this.spinner.hide();
      console.log(this.shopProductModels);
    })
  }

  getImage(imageName: string){
    // this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
    }, 5000);
    return `${environment.productImageApiUrl}${imageName}`;
  }
}
