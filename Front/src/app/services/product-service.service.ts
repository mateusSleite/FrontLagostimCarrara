import { Injectable } from '@angular/core';
import { ApiProductService } from './api-product.service';
import { ProductData } from '../dto/product-data';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {
  constructor(private http: ApiProductService) { }

  register(data: ProductData, callback: any = null, errorCallback: any = null) {
    this.http.post('/product/new', data)
      .subscribe(
        (response: any) => {
          if (callback) {
            callback(response);
          }
        },
        (error: any) => {
          console.error('Error registering product:', error);
          if (errorCallback) {
            errorCallback(error);
          }
        }
      );
  }
}
