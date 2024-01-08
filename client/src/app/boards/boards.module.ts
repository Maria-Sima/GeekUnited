import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardsComponent } from './boards/boards.component';
import { BoardByIdComponent } from './boardById/board-by-id.component';
import { SharedModule } from '../shared/shared.module';
import { BoardCardComponent } from './board-card/board-card.component';

@NgModule({
  declarations: [BoardsComponent, BoardByIdComponent, BoardCardComponent, BoardByIdComponent],
  imports: [CommonModule, SharedModule],
})
export class BoardsModule {}
