import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import{environment} from 'src/environments/environment';
import { CategoryModel } from '@app/_models/shop';


@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private readonly shopEndpoint = 'shopping/';
  constructor(private http:HttpClient) { }

  GetCategoryForShopById(webCategoryID:any)
  {
     return this.http.get<CategoryModel[]>(`${environment.apiUrl}${this.shopEndpoint}GetItemCategory/${webCategoryID}`);
  }

}
