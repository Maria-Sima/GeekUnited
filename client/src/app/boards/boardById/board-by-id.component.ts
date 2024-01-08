import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBoard } from '../../core/models/board';
import { AccountService } from '../../account/account.service';

@Component({
  selector: 'app-boardById',
  templateUrl: './board-by-id.component.html',
  styleUrls: ['./board-by-id.component.scss'],
})
export class BoardByIdComponent implements OnInit {
  user: any;
  boardDetails!: IBoard;
  boardTabs = [
    { label: 'Threads', value: 'threads', icon: '/assets/threads-icon.png' }, // Adjust the icon path
    { label: 'Members', value: 'members', icon: '/assets/members-icon.png' }, // Adjust the icon path
    { label: 'Requests', value: 'requests', icon: '/assets/requests-icon.png' }, // Adjust the icon path
  ];

  constructor(
    private route: ActivatedRoute,
    private authService: AccountService,
    private boardService: BoardService,
  ) {}

  async ngOnInit() {
    this.user = await this.authService.currentUser$;
    if (!this.user) {
      return;
    }

    const boardId = this.route.snapshot.params[id];
    this.boardDetails = await this.boardService.fetchBoardDetails(boardId);
  }
}
