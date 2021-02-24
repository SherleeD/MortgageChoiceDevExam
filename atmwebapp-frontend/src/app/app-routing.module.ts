import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BalanceinquiryComponent } from './components/balanceinquiry/balanceinquiry.component';
import { DepositComponent } from './components/deposit/deposit.component';
import { WithdrawalComponent } from './components/withdrawal/withdrawal.component';
import { LoginComponent } from './components/login/login.component';
import { MenuComponent } from './components/menu/menu.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },  
  { path: 'inquiry-savings', component: BalanceinquiryComponent },
  { path: 'deposit-savings', component: DepositComponent },
  { path: 'withdrawal-savings', component: WithdrawalComponent },
  { path: 'login', component: LoginComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

}
