import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../auth/auth.service';
import { UserResponse } from '../../../core/models/userResponse';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.scss'],
})
export class CreatePostComponent implements OnInit {
  userId: string = '';
  user!: UserResponse;

  constructor(
    private router: Router,
    private auth: AuthService,
  ) {}

  ngOnInit(): void {
    this.initData();
  }

  async initData() {
    // this.user = await this.auth.currentUser$;
    // if (!this.user) return;
    //
    // const userInfo = await this.auth.loadCurrentUser(this.user.id);
    // if (!userInfo?.onboarded) {
    //   redirect('/onboarding');
    //   return;
    // }
    //
    // this.userId = userInfo._id;
  }
}
