import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';  


//components
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { LoginComponent } from './components/login/login.component';

import { BalanceinquiryComponent } from './components/balanceinquiry/balanceinquiry.component';
import { DepositComponent } from './components/deposit/deposit.component';
import { WithdrawalComponent } from './components/withdrawal/withdrawal.component';


//services
import { AccountService} from './services/account.service';

import { AppRoutingModule } from './app-routing.module';

import { DropdownDirective } from './shared/dropdown.directive';
import { DatePipe } from '@angular/common';
import { AtmwebappComponent } from './components/atmwebapp/atmwebapp.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    BalanceinquiryComponent,
    DepositComponent,
    WithdrawalComponent,
    MenuComponent,
    DropdownDirective,
    AtmwebappComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [AccountService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
