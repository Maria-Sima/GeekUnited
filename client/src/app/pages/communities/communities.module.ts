import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommunitiesComponent } from './communities/communities.component';
import { CommunityPageComponent } from './communityById/community-page.component';
import { SharedModule } from '../../components/shared/shared.module';
import { CardsModule } from '../../components/cards/cards.module';

@NgModule({
  declarations: [CommunitiesComponent, CommunityPageComponent],
  imports: [CommonModule, SharedModule, CardsModule],
})
export class CommunitiesModule {}
