import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit, OnDestroy {  
  isAuthenticated = false;

  //TypeScript 2.7 includes a strict class checking where all the properties should be initialized in the constructor. A workaround is to add the ! as a postfix to the variable name
  private userSub!: Subscription;
  

  constructor(        
    private loginService: LoginService ) 
    { }

  ngOnInit() {
    this.userSub = this.loginService.user.subscribe(user => {
      this.isAuthenticated = !!user;            
    });
  }
  
  onLogout() {
    this.loginService.logout();
  }

  ngOnDestroy() {
    this.userSub.unsubscribe();
  }
 
}
