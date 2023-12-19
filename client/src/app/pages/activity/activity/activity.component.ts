import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../auth/auth.service';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.scss'],
})
export class ActivityComponent implements OnInit {
  activity: any[] = [];

  constructor(
    private router: Router,
    private authService: AuthService,
    private userService: UserService,
  ) {}

  async ngOnInit() {
    await this.authService.currentUser$.subscribe(async (userInfo) => {
      if (!userInfo || userInfo.onboarded) {
        this.router.navigate(['/']);
        return;
      }

      if (!userInfo.onboarded) {
        this.redirect('/onboarding');
        return;
      }

      await this.userService.getActivity(userInfo.id).subscribe((response) => {
        this.activity = response;
      });
    });
  }

  redirectToThread(parentId: string) {
    this.router.navigate([`/thread/${parentId}`]);
  }

  private redirect(path: string) {
    this.router.navigate([path]);
  }
}
