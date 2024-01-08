import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { AuthenthicatorComponent } from './authenthicator/authenthicator.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { OnboardingComponent } from './onboarding/onboarding.component';
import { HttpClientModule } from '@angular/common/http';
import { AccountService } from './account.service';
import { AccountProfileComponent } from './components/account-profile/account-profile.component';

@NgModule({
  declarations: [
    SignUpComponent,
    SignInComponent,
    AuthenthicatorComponent,
    OnboardingComponent,
    AccountProfileComponent,
  ],
  imports: [CommonModule, ReactiveFormsModule, SharedModule, MatButtonModule, MatCardModule, HttpClientModule],
  providers: [AccountService],
  exports: [SignUpComponent, SignInComponent],
})
export class AccountModule {}
