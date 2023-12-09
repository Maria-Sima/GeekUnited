import {Component, Input} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent {
  @Input() pageNumber: number = 1;
  @Input() isNext: boolean = false;
  @Input() path: string = '';

  constructor(private router: Router) {}

  handleNavigation(type: string): void {
    let nextPageNumber = this.pageNumber;

    if (type === 'prev') {
      nextPageNumber = Math.max(1, this.pageNumber - 1);
    } else if (type === 'next') {
      nextPageNumber = this.pageNumber + 1;
    }

    const route = nextPageNumber > 1 ? `/${this.path}?page=${nextPageNumber}` : `/${this.path}`;
    this.router.navigate([route]);
  }
}
