import { Component } from '@angular/core';
import * as CpfCnpjValidator from 'cpf-cnpj-validator';
import { ClientServiceService } from '../client-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dados',
  templateUrl: './dados.component.html',
  styleUrls: ['./dados.component.css']
})
export class DadosComponent {

  nome: string = '';
  cpf: string = '';
  email: string = '';
  data: Date | null = null;
  numero: string = '';
  senha: string = '';
  confirmpassword: string = '';

  senhaError: boolean = false;
  cpfError: boolean = false;
  empty: boolean = false;

  constructor(
    private client: ClientServiceService,
    private router: Router
  ) {}

  create() {

    if (this.nome == '' || this.cpf == '' || this.email == '' || !this.data || this.numero == ''|| this.senha == '' || this.confirmpassword == '') {
      this.empty = true;
      return;
    }

    if (!CpfCnpjValidator.cpf.isValid(this.cpf)) {
      this.cpfError = true;
      
      this.router.navigate(['/cadastro']);
      return;
    }

    if (this.senha !== this.confirmpassword) {
      this.cpfError = false;
      this.empty = false;
      this.senhaError = true;
      return;
    }

    this.client.register({
      Nome: this.nome,
      Cpf: this.cpf,
      Email: this.email,
      DataNasc: this.data,
      Numero: this.numero,
      Senha: this.senha,
    });

    this.router.navigate(['/login']);
  }
}
