import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { IUser } from '../../../core/models/user';

@Component({
  selector: 'app-posts-card',
  templateUrl: './posts-card.component.html',
  styleUrls: ['./posts-card.component.scss'],
})
export class PostsCardComponent {
  @Input() id!: string;
  @Input() currentUserId: string = '';
  @Input() parentId: string | null = null;
  @Input() content: string = '';
  @Input() author!: IUser;
  @Input() community: { id: string; name: string; image: string } | null = null;
  @Input() createdAt: string = '';
  @Input() comments: string[] = [];
  @Input() isComment?: boolean = false;

  constructor(private router: Router) {}

  formatDateString(dateString: string): string {
    return dateString;
  }

  navigateToThread(): void {
    this.router.navigate(['/post', this.id]);
  }

  navigateToProfile(authorId: string): void {
    this.router.navigate(['/profile', authorId]);
  }

  navigateToCommunity(communityId: string): void {
    this.router.navigate(['/boards', communityId]);
  }
}
