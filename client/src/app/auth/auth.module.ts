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
import { OnboardingComponent } from './onboarding/onboarding.component';
import { FormsComponentsModule } from '../components/forms/forms-components.module';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from './auth.service';

@NgModule({
  declarations: [
    RegisterComponent,
    LoginComponent,
    EmailVerificationComponent,
    AuthenthicatorComponent,
    OnboardingComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule,
    MatButtonModule,
    MatCardModule,
    FormsComponentsModule,
    HttpClientModule,
  ],
  providers: [AuthService],
  exports: [RegisterComponent, LoginComponent, EmailVerificationComponent],
})
export class AuthModule {}
