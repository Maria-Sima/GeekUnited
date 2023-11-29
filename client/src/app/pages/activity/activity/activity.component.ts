import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../../auth/account.service';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.scss'],
})
export class ActivityComponent implements OnInit {
  activity: any[] = [];

  constructor(
    private router: Router,
    private authService: AccountService,
  ) {}

  async ngOnInit() {
    const user = await this.authService.currentUser$;
    if (!user) {
      return;
    }

    const userInfo = await fetchUser(user.id);
    if (!userInfo?.onboarded) {
      this.redirect('/onboarding');
      return;
    }

    this.activity = await getActivity(userInfo._id);
  }

  redirectToThread(parentId: string) {
    this.router.navigate([`/thread/${parentId}`]);
  }

  private redirect(path: string) {
    this.router.navigate([path]);
  }
}
