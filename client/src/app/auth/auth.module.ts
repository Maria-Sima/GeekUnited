import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './sign-up/register.component';
import { LoginComponent } from './sign-in/login.component';
import { EmailVerificationComponent } from './email-verification/email-verification.component';
import { AuthenthicatorComponent } from './authenthicator/authenthicator.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [RegisterComponent, LoginComponent, EmailVerificationComponent, AuthenthicatorComponent],
  imports: [CommonModule, ReactiveFormsModule, SharedModule, MatButtonModule, MatCardModule],
  exports: [RegisterComponent, LoginComponent, EmailVerificationComponent],
})
export class AuthModule {}
