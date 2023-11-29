import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-thread',
  templateUrl: './thread.component.html',
  styleUrls: ['./thread.component.scss'],
})
export class ThreadComponent implements OnInit {
  user: any;
  userInfo: any;
  params: any;
  thread: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    // Add your actual services here
  ) {}

  async ngOnInit() {
    await this.initData();
  }

  async initData() {
    this.params = this.route.snapshot.data.params; // Adjust based on your routing configuration

    if (!this.params.id) return;

    this.user = await currentUser();
    if (!this.user) return;

    this.userInfo = await fetchUser(this.user.id);
    if (!this.userInfo?.onboarded) {
      redirect('/onboarding');
      return;
    }

    this.thread = await fetchThreadById(this.params.id);
  }
}
