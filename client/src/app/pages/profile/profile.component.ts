import { Component } from '@angular/core';
import { profileTabs } from '../../utils/constants';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent {
  user: any;
  userInfo: any;
  profileTabs: any[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    // Add your actual services here
  ) {
    this.profileTabs = profileTabs; // Update to your actual tabs data
  }

  async ngOnInit() {
    await this.initData();
  }

  async initData() {
    this.user = await currentUser();
    if (!this.user) return;

    this.userInfo = await fetchUser(this.route.snapshot.params.id);
    if (!this.userInfo?.onboarded) {
      redirect('/onboarding');
      return;
    }
  }
}
