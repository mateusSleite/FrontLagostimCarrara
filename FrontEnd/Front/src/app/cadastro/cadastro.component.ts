import { Component } from '@angular/core';
import { ClientServiceService } from '../client-service.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.css'
})
export class CadastroComponent {
  
  // constructor (
  //   private client: ClientServiceService) { }
    
  username: string = '';
  password: string = ''; 

  // logar()
  // {
  //   this.client.login({
  //     Cpf: this.username,
  //     Senha: this.password
  //   }, (result: any) => {
  //     if (result == null)
  //     {
  //       alert('Senha ou usuário incorreto!')
  //     }
  //     else
  //     {
  //       sessionStorage.setItem('jwt', JSON.stringify(result))
  //     }
  //   })
  // }

}
