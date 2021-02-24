import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, tap } from 'rxjs/operators';
import { throwError, BehaviorSubject } from 'rxjs';

import { User } from '../models/user.model';

export interface AuthResponseData {  
  acctId: number;
  accountNumber: string;
  firstname: string;
  lastname: string;
  accountType: number;

}

@Injectable({ providedIn: 'root' })
export class LoginService {
  user = new BehaviorSubject<User>(null);

  constructor(private http: HttpClient, private router: Router) {}

  login(acctnumber: string, acctpin: string) {
    return this.http
      .post<AuthResponseData>(
        'https://localhost:44309/api/account',
        {
            accountNumber: acctnumber,
            accountPIN: acctpin          
        }
      )
      .pipe(
        catchError(this.handleError),
        tap(resData => {
          this.handleAuthentication(
            resData.acctId,
            resData.accountNumber           

          );
        })
      );
  }

  logout() {
    this.user.next(null);
    this.router.navigate(['/auth']);
  }

  private handleAuthentication(
    accountNumber: string,
    acctId: string
  ) {
    
    const user = new User(accountNumber, acctId);
    this.user.next(user);
  }

  private handleError(errorRes: HttpErrorResponse) {
    let errorMessage = 'An unknown error occurred!';
    if (!errorRes.error || !errorRes.error.error) {
      return throwError(errorMessage);
    }
    switch (errorRes.error.error.message) {      
      case 'ACCOUNT_NOT_FOUND':
        errorMessage = 'Account not found.';
        break;
      case 'INVALID_PIN':
        errorMessage = 'Invalid PIN.';
        break;
    }
    return throwError(errorMessage);
  }
}
