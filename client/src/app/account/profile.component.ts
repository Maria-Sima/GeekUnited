import { Component } from '@angular/core';
import { profileTabs } from '../utils/constants';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from './account.service';
import { Observable } from 'rxjs';
import { IUser } from '../core/models/user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../profile/profile.component.scss'],
})
export class ProfileComponent {
  userInfo$!: Observable<IUser | null>;
  profileTabs: any[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
  ) {
    this.profileTabs = profileTabs;
  }

  async ngOnInit() {
    await this.initData();
  }

  async initData() {
    this.userInfo$ = await this.accountService.currentUser$;
    if (!this.userInfo$) {
      this.router.navigateByUrl('/auth');
    }
  }
}
