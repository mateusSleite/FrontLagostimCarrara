import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { MatDialogRef } from '@angular/material/dialog';
import { ProductServiceService } from '../../services/product-service.service';

@Component({
  selector: 'app-add-product-modal',
  templateUrl: './add-product-modal.component.html',
  styleUrls: ['./add-product-modal.component.css'],
})
export class AddProductModalComponent {

  name: string = '';
  price: number = 0;
  ingredients: string = '';
  description: string = '';

  constructor(
    private product: ProductServiceService,
    private router: Router,
    private http: HttpClient,
    private dialogRef: MatDialogRef<AddProductModalComponent>
  ) {}

  create() {
    this.http
      .post('http://localhost:5229/product/imagem', this.formData)
      .subscribe((result: any) => {
        this.product.register(
          {
            Nome: this.name,
            Preco: this.price,
            Ingredientes: this.ingredients,
            Descricao: this.description,
            IDImagem: result.imgID,
          },
          (response: any) => {
            this.dialogRef.close();
          }
        );
      });
  }

  private formData = new FormData();

  uploadFile = (files: any) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = files[0] as File;
    this.formData = new FormData();
    this.formData.append('file', fileToUpload, fileToUpload.name);

    var jwt = sessionStorage.getItem('jwt');
    if (jwt == null) return;
    this.formData.append('jwt', jwt);
  };
}
