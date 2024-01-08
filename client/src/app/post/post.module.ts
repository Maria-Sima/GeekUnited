import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostComponent } from './post.component';

import { CreatePostComponent } from './create-post/create-post.component';
import { CoreModule } from '../core/core.module';
import { PostsCardComponent } from './components/posts-card/posts-card.component';
import { RouterLink } from '@angular/router';

@NgModule({
  declarations: [PostComponent, CreatePostComponent, PostsCardComponent],
  imports: [CommonModule, CoreModule, RouterLink],
})
export class PostModule {}
