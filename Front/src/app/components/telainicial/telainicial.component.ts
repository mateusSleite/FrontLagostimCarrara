import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-telainicial',
  templateUrl: './telainicial.component.html',
  styleUrls: ['./telainicial.component.css']
})
export class TelainicialComponent implements OnInit {
  jwtToken: string | null;
  nomeUsuario: string | undefined;
  isAdm : boolean | undefined;
  objJwt: any;

  constructor() {
    this.jwtToken = sessionStorage.getItem('jwt');

    if (this.jwtToken) {
      const parts = this.jwtToken.split('.');
      this.objJwt = JSON.parse(atob(parts[1]));
    }
  }

  ngOnInit(): void {

    this.isAdm = this.objJwt.isAdm;

    console.log(this.isAdm);

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
