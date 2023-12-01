import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThreadComponent } from './thread.component';
import { CardsModule } from '../../components/cards/cards.module';

@NgModule({
  declarations: [ThreadComponent],
  imports: [CommonModule, CardsModule],
})
export class ThreadModule {}
