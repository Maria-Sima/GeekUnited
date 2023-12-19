import { NgModule } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { AccountProfileComponent } from './account-profile/account-profile.component';
import { CommentComponent } from './comment/comment.component';
import { DeletePostComponent } from './delete-post/delete-post.component';
import { AddPostComponent } from './add-post/add-post.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [AccountProfileComponent, CommentComponent, DeletePostComponent, AddPostComponent],
  imports: [CommonModule, ReactiveFormsModule, SharedModule, NgOptimizedImage],
  exports: [DeletePostComponent, AddPostComponent, AccountProfileComponent],
})
export class FormsComponentsModule {}
