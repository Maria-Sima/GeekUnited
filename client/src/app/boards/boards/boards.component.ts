import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../../account/account.service';
import { IBoard } from '../../core/models/board';

@Component({
  selector: 'app-boards',
  templateUrl: './boards.component.html',
  styleUrls: ['./boards.component.scss'],
})
export class BoardsComponent implements OnInit {
  result: { boards: IBoard[]; pageNumber: number; isNext: boolean } | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AccountService,
    private boardService: BoardService,
  ) {}

  async ngOnInit() {
    const user = await this.authService.currentUser$;
    if (!user) {
      return;
    }

    const searchParams = this.route.snapshot.queryParams;
    this.result = await this.boardService.fetchCommunities({
      searchString: searchParams.q,
      pageNumber: searchParams.page ? +searchParams.page : 1,
      pageSize: 25,
    });
  }

  private redirect(path: string) {
    this.router.navigate([path]);
  }
}
