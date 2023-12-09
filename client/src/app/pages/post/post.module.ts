import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostComponent } from './post.component';
import { CardsModule } from '../../components/cards/cards.module';
import { CreatePostComponent } from './create-post/create-post.component';
import { CoreModule } from '../../core/core.module';

@NgModule({
  declarations: [PostComponent, CreatePostComponent],
  imports: [CommonModule, CardsModule, CoreModule],
})
export class PostModule {}
