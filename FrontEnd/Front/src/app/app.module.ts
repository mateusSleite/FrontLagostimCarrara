import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ClientServiceService } from './client-service.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TelaInicialComponent } from './tela-inicial/tela-inicial.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { DadosComponent } from './dados/dados.component';

const routes: Routes = [
  { path: 'tela-inicial', component: TelaInicialComponent },
  { path: 'login', component: CadastroComponent },
  { path: 'cadastro', component: DadosComponent },
  { path: '', redirectTo: '/tela-inicial', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    TelaInicialComponent,
    CadastroComponent,
    DadosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),
    FormsModule,
    HttpClientModule
  ],
  exports: [RouterModule],
  providers: [ClientServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
