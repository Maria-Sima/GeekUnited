import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountProfileComponent } from './account-profile/account-profile.component';
import { CommentComponent } from './comment/comment.component';
import { DeletePostComponent } from './delete-post/delete-post.component';
import { AddPostComponent } from './add-post/add-post.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [AccountProfileComponent, CommentComponent, DeletePostComponent, AddPostComponent],
  imports: [CommonModule, ReactiveFormsModule],
  exports: [DeletePostComponent, AddPostComponent],
})
export class FormsComponentsModule {}
