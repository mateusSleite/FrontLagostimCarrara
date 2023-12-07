import { Injectable } from '@angular/core';
import { ApiImageService } from './api-image.service';

@Injectable({
  providedIn: 'root'
})
export class ImageServiceService {
  constructor(private http: ApiImageService) { }

  getImage()
  {
    return this.http.get('http://localhost:5229/product/image')
  }

}