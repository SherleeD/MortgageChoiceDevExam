import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-withdrawal',
  templateUrl: './withdrawal.component.html',
  styleUrls: ['./withdrawal.component.css']
})
export class WithdrawalComponent implements OnInit {
  
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
  }

  onWithdrawPost(postData: { acctId: number; transactionType: number; amountWithdraw: number }) {
    // Send Http request
    postData.acctId = 1;
    postData.transactionType = 2;        
    console.log(postData);

    // Send Http request
    this.http
      .post(
        'https://localhost:44309/api/account/AccountWithdrawal',
        postData
      )
      .subscribe(responseData => {
        console.log(responseData);
      });    
  }

}
