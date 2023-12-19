import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../auth/auth.service';
import { PostsService } from './posts.service';
import { IPost } from '../../core/models/post';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {
  user: any;
  userInfo: any;
  post!: IPost;
  params!: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private auth: AuthService,
    private postsService: PostsService,
  ) {}

  async ngOnInit() {
    await this.initData();
  }

  async initData() {
    this.params = this.route.snapshot.paramMap.get('id')!;

    if (!this.params) return;

    this.user = this.auth.currentUser$;
    if (!this.user) return;

    this.userInfo = await this.auth.loadCurrentUser(this.user.id);
    if (!this.userInfo?.onboarded) {
      await this.router.navigateByUrl('/onboarding');
      return;
    }
    this.loadPost();
  }

  loadPost() {
    this.postsService.getPost(this.params).subscribe(
      (post) => {
        this.post = post;
      },
      (error) => {
        console.log(error);
      },
    );
  }
}
