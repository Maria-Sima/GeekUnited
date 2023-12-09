import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user.ts-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.scss'],
})
export class UserCardComponent {
  @Input() id: string = '';
  @Input() name: string = '';
  @Input() username: string = '';
  @Input() imgUrl: string = '';
  @Input() personType: string = '';

  isCommunity: boolean = this.personType === 'Community';

  constructor(private router: Router) {}

  navigateToProfile(): void {
    if (this.isCommunity) {
      this.router.navigate(['/boards', this.id]);
    } else {
      this.router.navigate(['/profile', this.id]);
    }
  }
}
