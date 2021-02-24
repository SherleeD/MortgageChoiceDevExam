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
  
  isLoading = false;
  error: string = '';

  constructor(private loginService: LoginService, private router: Router) {}


  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }
    const accountNumber = form.value.accountNumber;
    const accountPIN = form.value.accountPIN;

    let authObs: Observable<AuthResponseData>;

    this.isLoading = true;

    
      authObs = this.loginService.login(accountNumber, accountPIN);
    

    authObs.subscribe(
      resData => {
        console.log(resData);
        this.isLoading = false;
        this.router.navigate(['/recipes']);
      },
      errorMessage => {
        console.log(errorMessage);
        this.error = errorMessage;
        this.isLoading = false;
      }
    );

    form.reset();
  }
      

     

  

}
