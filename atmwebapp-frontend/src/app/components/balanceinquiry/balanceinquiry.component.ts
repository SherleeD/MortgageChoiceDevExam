import { Component, OnInit, Inject } from '@angular/core';
import { DatePipe } from '@angular/common';

import { HttpClient } from '@angular/common/http';

//rxjs
import { Observable } from 'rxjs';

//model
import { Account } from '../../shared/account.model';

//service
import { AccountService } from '../../services/account.service';



@Component({
  selector: 'app-balanceinquiry',
  templateUrl: './balanceinquiry.component.html',
  styleUrls: ['./balanceinquiry.component.css'],
  providers: [DatePipe]
})

export class BalanceinquiryComponent implements OnInit {
  
  today: number = Date.now();
  acctId = "1";  
  acctnumber = "";
  error = null;
  

  constructor(
    private accountService: AccountService,
    private http: HttpClient,
  ) { }

  ngOnInit() {
    this.accountService.getAccountDetails(this.acctId)
    .subscribe(useracct => {
      //success      
      console.log(useracct);
      this.acctnumber = useracct.accountNumber;
      console.log(this.acctnumber);
    }, error => {
      this.error = error.message;
    }
    
    
    );
  }

}
