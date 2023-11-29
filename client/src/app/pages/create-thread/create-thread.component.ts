import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-thread',
  templateUrl: './create-thread.component.html',
  styleUrls: ['./create-thread.component.scss'],
})
export class CreateThreadComponent implements OnInit {
  userId: string = '';

  constructor(
    private router: Router,
    // Add your actual services here
  ) {}

  ngOnInit(): void {
    this.initData();
  }

  async initData() {
    const user = await currentUser();
    if (!user) return;

    const userInfo = await fetchUser(user.id);
    if (!userInfo?.onboarded) {
      redirect('/onboarding');
      return;
    }

    this.userId = userInfo._id;
  }
}
