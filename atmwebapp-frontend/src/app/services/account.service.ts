import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Validators, FormBuilder } from '@angular/forms';

import { Account } from '../shared/account.model';

import { Observable } from 'rxjs';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
    providedIn: 'root'
})

export class AccountService {

    private serviceUrl = 'https://localhost:44309/api/account';

    constructor(private http: HttpClient) { }

    /**
    * Call api to get account details
    */
    getAccountDetails($key: string): Observable<Account> {

        var url = this.serviceUrl + '/' + $key;

        return this.http.get<Account>(url);
    }


}