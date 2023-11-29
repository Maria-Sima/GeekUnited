import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountProfileComponent } from './account-profile/account-profile.component';
import { CommentComponent } from './comment/comment.component';
import { DeleteThreadComponent } from './delete-thread/delete-thread.component';
import { PostThreadComponent } from './post-thread/post-thread.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [AccountProfileComponent, CommentComponent, DeleteThreadComponent, PostThreadComponent],
  imports: [CommonModule, ReactiveFormsModule],
  exports: [DeleteThreadComponent, PostThreadComponent],
})
export class FormsComponentsModule {}
