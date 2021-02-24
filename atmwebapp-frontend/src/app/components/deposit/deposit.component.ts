import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.css']
})
export class DepositComponent implements OnInit {

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
  }

  onDepositPost(postData: { acctId: number; transactionType: number; amountDeposit: number }) {
    // Send Http request
    postData.acctId = 2;
    postData.transactionType = 3;        
    console.log(postData);

    // Send Http request
    this.http
      .post(
        'https://localhost:44309/api/account/AccountDeposit',
        postData
      )
      .subscribe(responseData => {
        console.log(responseData);
      });    
  }

}
