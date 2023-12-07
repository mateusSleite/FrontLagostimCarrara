import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddProductModalComponent } from '../add-product-modal/add-product-modal.component';
import { ProductServiceService } from '../../services/product-service.service';

@Component({
  selector: 'app-cardapio',
  templateUrl: './cardapio.component.html',
  styleUrls: ['./cardapio.component.css']
})
export class CardapioComponent {
  jwtToken: string | null;
  isAdm: boolean | undefined;
  objJwt: any;
  produtos: any[] = [];

  constructor(
    private dialog: MatDialog,
    private service: ProductServiceService,) {
    this.jwtToken = sessionStorage.getItem('jwt');
    if (this.jwtToken) {
      const parts = this.jwtToken.split('.');
      this.objJwt = JSON.parse(atob(parts[1]));
      this.isAdm = this.objJwt.isAdm;
    }
  }

  ngOnInit() {
    this.loadAll()
  }

  loadAll()
  {
    this.service.getProducts().subscribe(
      (produto : any) => {
        this.produtos = []
        produto.a.forEach((x:any) => this.produtos.push(x))
      },
      (error) => {
        console.error('Não foi possível obter produtos', error)
      });
  }

  addproduct()
  {
    if (this.isAdm) {
      const dialogRef = this.dialog.open(AddProductModalComponent, {
        width: '400px',
      });

      dialogRef.afterClosed().subscribe(result => {
        console.log('O modal foi fechado', result);
        window.location.reload();
      });
    } else {
      console.log('Usuário não autorizado a adicionar produtos.');
    }
  }

}
