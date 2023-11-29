import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-comunity-card',
  templateUrl: './comunity-card.component.html',
  styleUrls: ['./comunity-card.component.scss'],
})
export class ComunityCardComponent {
  @Input() id: string = '';
  @Input() name: string = '';
  @Input() username: string = '';
  @Input() imgUrl: string = '';
  @Input() bio: string = '';
  @Input() members: { image: string }[] = [];
}
