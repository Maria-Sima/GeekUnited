import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../account/account.service';
import { PostsService } from './posts.service';
import { IPost } from '../core/models/post';
import { IUser } from '../core/models/user';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {
  user!: Observable<IUser>;
  userInfo?: IUser;
  post!: IPost;
  params!: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private auth: AccountService,
    private postsService: PostsService,
  ) {}

  async ngOnInit() {
    await this.initData();
  }

  async initData() {
    this.params = this.route.snapshot.paramMap.get('id')!;

    if (!this.params) {
      return;
    }

    this.user = this.auth.currentUser$;

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
