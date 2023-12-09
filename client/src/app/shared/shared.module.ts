import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterLink } from '@angular/router';
import { FormInputComponent } from './form-input/form-input.component';
import { LoadingComponent } from '../core/loading/loading.component';
import { FormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { LeftSideBarComponent } from './left-side-bar/left-side-bar.component';
import { PaginationComponent } from './pagination/pagination.component';
import { RightSideBarComponent } from './right-side-bar/right-side-bar.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { ProfileHeaderComponent } from './profile-header/profile-header.component';
import { SearchbarComponent } from './search-bar/search-bar.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BottomBarComponent } from './bottom-bar/bottom-bar.component';

@NgModule({
  declarations: [
    NavBarComponent,
    FormInputComponent,
    LoadingComponent,
    LeftSideBarComponent,
    PaginationComponent,
    RightSideBarComponent,
    SearchbarComponent,
    TopBarComponent,
    ProfileHeaderComponent,
    BottomBarComponent,
  ],
  imports: [CommonModule, RouterLink, FormsModule, MatProgressSpinnerModule, NgxSpinnerModule],
  exports: [
    NavBarComponent,
    FormInputComponent,
    LoadingComponent,
    PaginationComponent,
    SearchbarComponent,
    TopBarComponent,
    RightSideBarComponent,
    BottomBarComponent,
    SearchbarComponent,
    ProfileHeaderComponent,
    LeftSideBarComponent,
  ],
})
export class SharedModule {}
