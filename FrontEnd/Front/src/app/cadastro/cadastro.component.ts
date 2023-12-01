import { Component } from '@angular/core';
import { ClientServiceService } from '../client-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.css',
})
export class CadastroComponent {
  constructor(private client: ClientServiceService,
    private router: Router) {}

  username: string = '';
  password: string = '';

  erroLogin: boolean = false;

  logar() {

    this.username = this.username.replace(/[.-]/g, '');

    this.client.login(
      {
        Cpf: this.username,
        Senha: this.password,
      },
      (result: any) => {
        if (result == null) {
          this.erroLogin = true;
          this.router.navigate(['/login']);
        } else {
          sessionStorage.setItem('jwt', JSON.stringify(result));
          this.router.navigate(['/']);
        }
      }
    );
  }
}
