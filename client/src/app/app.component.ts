import { Component, OnInit } from '@angular/core';
import { AccountService } from './auth/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  constructor(public auth: AccountService) {}

  ngOnInit() {}

  logout() {
    this.auth.logout();
  }
}
