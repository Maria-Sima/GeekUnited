import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { UserCardComponent } from './user-card/user-card.component';
import { ThreadsCardComponent } from './threads-card/threads-card.component';
import { ComunityCardComponent } from './comunity-card/comunity-card.component';
import { FormsComponentsModule } from '../forms/forms-components.module';

@NgModule({
  declarations: [UserCardComponent, ThreadsCardComponent, ComunityCardComponent],
  imports: [CommonModule, RouterLink, FormsComponentsModule],
  exports: [ComunityCardComponent, ThreadsCardComponent, UserCardComponent],
})
export class CardsModule {}
