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
  private userSub: Subscription;

  constructor(    
    private loginService: LoginService
  ) {}

  ngOnInit() {
    this.userSub = this.loginService.user.subscribe(user => {
      this.isAuthenticated = !!user;
      console.log(!user);
      console.log(!!user);
    });
  }
  
  onLogout() {
    this.loginService.logout();
  }

  ngOnDestroy() {
    this.userSub.unsubscribe();
  }
 
}
