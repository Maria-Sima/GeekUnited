import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-board-card',
  templateUrl: './board-card.component.html',
  styleUrls: ['./board-card.component.scss'],
})
export class BoardCardComponent {
  @Input() id: string = '';
  @Input() name: string = '';
  @Input() username: string = '';
  @Input() imgUrl: string = '';
  @Input() bio: string = '';
  @Input() members: { image: string }[] = [];
}
