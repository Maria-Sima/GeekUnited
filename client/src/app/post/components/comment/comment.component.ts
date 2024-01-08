import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss'],
})
export class CommentComponent implements OnInit {
  threadId: string = ''; // Adjust the type based on your needs
  currentUserImg: string = ''; // Adjust the type based on your needs
  currentUserId: string = ''; // Adjust the type based on your needs

  commentForm!: FormGroup;

  constructor(
    private router: Router,
    // private commentService: CommentService, // Adjust based on your comment service
    private fb: FormBuilder,
  ) {}

  ngOnInit(): void {
    this.threadId = 'yourThreadId'; // Replace with the actual post ID
    this.currentUserImg = 'yourCurrentUserImg'; // Replace with the actual user.ts image URL
    this.currentUserId = 'yourCurrentUserId'; // Replace with the actual user.ts ID

    this.commentForm = this.fb.group({
      thread: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.commentForm.valid) {
      const values = this.commentForm.value;

      // Call your addCommentToThread function here
      // Adjust the method based on your comment service method and addCommentToThread function
      // Example: this.commentService.addCommentToThread(this.threadId, values.post, this.currentUserId, '/');

      this.commentForm.reset();
    }
  }
}
