import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenthicatorComponent } from './authenthicator/authenthicator.component';
import { OnboardingComponent } from './onboarding/onboarding.component';

const routes: Routes = [
  { path: 'auth', component: AuthenthicatorComponent },
  { path: 'onboarding', component: OnboardingComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountRoutingModule {}
