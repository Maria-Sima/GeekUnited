import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardsComponent } from './boards/boards.component';
import { CommunityPageComponent } from './boardById/community-page.component';
import { SharedModule } from '../../shared/shared.module';
import { CardsModule } from '../../components/cards/cards.module';

@NgModule({
  declarations: [BoardsComponent, CommunityPageComponent],
  imports: [CommonModule, SharedModule, CardsModule],
})
export class BoardsModule {}
