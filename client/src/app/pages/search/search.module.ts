import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchComponent } from './search.component';
import { CardsModule } from '../../components/cards/cards.module';
import { SharedModule } from '../../components/shared/shared.module';

@NgModule({
  declarations: [SearchComponent],
  imports: [CommonModule, CardsModule, SharedModule],
})
export class SearchModule {}
