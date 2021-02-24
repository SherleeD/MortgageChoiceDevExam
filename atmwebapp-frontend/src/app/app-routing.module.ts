import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BalanceinquiryComponent } from './components/balanceinquiry/balanceinquiry.component';
import { DepositComponent } from './components/deposit/deposit.component';
import { WithdrawalComponent } from './components/withdrawal/withdrawal.component';
import { LoginComponent } from './components/login/login.component';
import { AtmwebappComponent } from './components/atmwebapp/atmwebapp.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/app-atmwebapp', pathMatch: 'full' },  
  { path: 'inquiry-savings', component: BalanceinquiryComponent },
  { path: 'deposit-savings', component: DepositComponent },
  { path: 'withdrawal-savings', component: WithdrawalComponent },
  { path: 'auth', component: LoginComponent },
  { path: 'app-atmwebapp', component: AtmwebappComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

}
