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
import { UserGuard } from './guard/user.guard';
import { CardapioComponent } from './cardapio/cardapio.component';
import { CupomComponent } from './cupom/cupom.component';


const routes: Routes = [
  { path: '', component: TelaInicialComponent },
  { path: 'login', component: CadastroComponent, canActivate: [UserGuard] },
  { path: 'cadastro', component: DadosComponent, canActivate: [UserGuard] },
  { path: 'cardapio', component: CardapioComponent},
  { path: 'cupom', component: CupomComponent},
  { path: '', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    TelaInicialComponent,
    CadastroComponent,
    DadosComponent,
    CardapioComponent,
    CupomComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),
    FormsModule,
    HttpClientModule
  ],
  exports: [RouterModule],
  providers: [ClientServiceService , UserGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
