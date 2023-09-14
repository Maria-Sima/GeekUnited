import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {PostComment} from "../../core/models/PostComment";

@Component({
  selector: 'app-reply',
  templateUrl: './reply.component.html',
  styleUrls: ['./reply.component.scss']
})
export class ReplyComponent implements OnInit {
  comments: PostComment[] = [];

  constructor(@Inject(MAT_DIALOG_DATA) private postId: string) {
  }

  ngOnInit(): void {
    this.getComments();
  }

  getComments() {
  }
  isCommentCreator(comment:PostComment) {
    return true;
  }

  onSend(commentInput: HTMLInputElement) {
    if (!(commentInput.value.length > 0)) return;
  }
}
