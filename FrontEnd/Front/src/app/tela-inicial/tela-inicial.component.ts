import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tela-inicial',
  templateUrl: './tela-inicial.component.html',
  styleUrls: ['./tela-inicial.component.css']
})
export class TelaInicialComponent implements OnInit {
  jwtToken: string | null;
  nomeUsuario: string | undefined;
  objJwt: any;

  constructor() {
    this.jwtToken = sessionStorage.getItem('jwt');

    if (this.jwtToken) {
      const parts = this.jwtToken.split('.');
      this.objJwt = JSON.parse(atob(parts[1]));
    }
  }

  ngOnInit(): void {

    if (this.jwtToken) {
      const partName = this.objJwt.name.split(' ');
      this.nomeUsuario = partName[0];

    } else {
      console.log('Token JWT não encontrado.');
    }
  }

  logout() {
    sessionStorage.removeItem('jwt');
    window.location.reload();
  }
}
