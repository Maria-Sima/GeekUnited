import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile.component';
import { ProfileByIdComponent } from './profile-by-id/profile-by-id.component';



@NgModule({
  declarations: [
    ProfileComponent,
    ProfileByIdComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ProfileModule { }
