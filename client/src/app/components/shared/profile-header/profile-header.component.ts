import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-profile-header',
  templateUrl: './profile-header.component.html',
  styleUrls: ['./profile-header.component.scss']
})
export class ProfileHeaderComponent {
  @Input() accountId: string = '';
  @Input() authUserId: string = '';
  @Input() name: string = '';
  @Input() username: string = '';
  @Input() imgUrl: string = '';
  @Input() bio: string = '';
  @Input() type?: string;

  isEditable(): boolean {
    return this.accountId === this.authUserId && this.type !== 'Community';
  }
}
