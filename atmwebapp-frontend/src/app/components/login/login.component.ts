import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';


import { Account } from '../../shared/account.model';

import { LoginService, AuthResponseData } from '../../services/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent {
  isLoginMode = true;
  error: string = '';

  constructor(private loginService: LoginService, private router: Router) {}


  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }

    const accountNumber = form.value.accountNumber;
    const accountPIN = form.value.accountPIN;

    let authObs: Observable<AuthResponseData>;

    console.log(form.value);

    authObs = this.loginService.login(accountNumber, accountPIN);

    authObs.subscribe(
      resData => {        
        console.log(resData);        
        this.router.navigate(['/app-atmwebapp']);
      },
      errorMessage => {      
        this.error = errorMessage;        
      }
    );    

    form.reset();
  }
      

     

  

}
