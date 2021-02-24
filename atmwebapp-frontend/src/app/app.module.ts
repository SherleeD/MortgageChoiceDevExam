import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';  


import { AppRoutingModule } from './app-routing.module';

//components
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { BalanceinquiryComponent } from './components/balanceinquiry/balanceinquiry.component';
import { DepositComponent } from './components/deposit/deposit.component';
import { WithdrawalComponent } from './components/withdrawal/withdrawal.component';
import { MenuComponent } from './components/menu/menu.component';

//services
import { AccountService} from './services/account.service';


import { DropdownDirective } from './shared/dropdown.directive';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    BalanceinquiryComponent,
    DepositComponent,
    WithdrawalComponent,
    MenuComponent,
    DropdownDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [AccountService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
