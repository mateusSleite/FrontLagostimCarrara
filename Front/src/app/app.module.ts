import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ClientServiceService } from '../app/services/client-service.service';
import { MatDialogModule } from '@angular/material/dialog';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserGuard } from './guards/user.guard';
import { CadastroComponent } from './components/cadastro/cadastro.component';
import { LoginComponent } from './components/login/login.component';
import { TelainicialComponent } from './components/telainicial/telainicial.component';
import { CardapioComponent } from './components/cardapio/cardapio.component';
import { CuponsComponent } from './components/cupons/cupons.component';
import { AddProductModalComponent } from './components/add-product-modal/add-product-modal.component';

const routes: Routes = [
  { path: '', component: TelainicialComponent },
  { path: 'login', component: LoginComponent, canActivate: [UserGuard] },
  { path: 'cadastro', component: CadastroComponent, canActivate: [UserGuard] },
  { path: 'cardapio', component: CardapioComponent},
  { path: 'cupom', component: CuponsComponent},
  { path: '', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    CadastroComponent,
    LoginComponent,
    TelainicialComponent,
    CardapioComponent,
    CuponsComponent,
    AddProductModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),
    FormsModule,
    HttpClientModule,
    MatDialogModule
  ],
  exports: [RouterModule],
  providers: [ClientServiceService, UserGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }