import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { UserCardComponent } from './user-card/user-card.component';
import { PostsCardComponent } from './posts-card/posts-card.component';
import { BoardCardComponent } from './board-card/board-card.component';
import { FormsComponentsModule } from '../forms/forms-components.module';

@NgModule({
  declarations: [UserCardComponent, PostsCardComponent, BoardCardComponent],
  imports: [CommonModule, RouterLink, FormsComponentsModule],
  exports: [BoardCardComponent, PostsCardComponent, UserCardComponent],
})
export class CardsModule {}
