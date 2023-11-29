import { Component } from '@angular/core';
import { ClientServiceService } from '../client-service.service';

@Component({
  selector: 'app-dados',
  templateUrl: './dados.component.html',
  styleUrls: ['./dados.component.css']
})
export class DadosComponent {

  nome: string = '';
  cpf: string = '';
  email: string = '';
  data: Date = new Date();
  numero: string = '';
  senha: string = '';
  confirmpassword: string = '';

  constructor(
    private client: ClientServiceService
  ) {}

  create() {
    this.client.register({
      Nome: this.nome,
      Cpf: this.cpf,
      Email: this.email,
      DataNasc: this.data,
      Numero: this.numero,
      Senha: this.senha,
    });
  }
}
