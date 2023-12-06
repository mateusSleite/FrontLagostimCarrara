import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddProductModalComponent } from '../add-product-modal/add-product-modal.component';

@Component({
  selector: 'app-cardapio',
  templateUrl: './cardapio.component.html',
  styleUrls: ['./cardapio.component.css']
})
export class CardapioComponent {
  jwtToken: string | null;
  isAdm: boolean | undefined;
  objJwt: any;

  constructor(private dialog: MatDialog) {
    this.jwtToken = sessionStorage.getItem('jwt');
    if (this.jwtToken) {
      const parts = this.jwtToken.split('.');
      this.objJwt = JSON.parse(atob(parts[1]));
      this.isAdm = this.objJwt.isAdm;
    }
  }

  addproduct()
  {
    if (this.isAdm) {
      const dialogRef = this.dialog.open(AddProductModalComponent, {
        width: '400px',
      });

      dialogRef.afterClosed().subscribe(result => {
        console.log('O modal foi fechado', result);
      });
    } else {
      console.log('Usuário não autorizado a adicionar produtos.');
    }
  }

}
