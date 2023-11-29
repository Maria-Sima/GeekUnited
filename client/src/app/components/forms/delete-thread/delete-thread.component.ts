import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-delete-thread',
  templateUrl: './delete-thread.component.html',
  styleUrls: ['./delete-thread.component.scss'],
})
export class DeleteThreadComponent {
  @Input() threadId: string = '';
  @Input() currentUserId: string = '';
  @Input() authorId: string = '';
  @Input() parentId: string | null = null;
  @Input() isComment?: boolean = false;

  constructor(private router: Router) {}

  shouldRenderDeleteButton(): boolean {
    return this.currentUserId === this.authorId && this.router.url !== '/';
  }

  onDeleteClick(): void {
    const parsedThreadId = JSON.parse(this.threadId);
    // deleteThread(parsedThreadId, this.router.url);

    if (!this.parentId || !this.isComment) {
      this.router.navigate(['/']);
    }
  }
}
