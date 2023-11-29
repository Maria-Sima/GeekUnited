import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { SharedModule } from './components/shared/shared.module';

import { RouterModule, RouterOutlet } from '@angular/router';

import { AuthModule } from './auth/auth.module';
import { BrowserModule } from '@angular/platform-browser';
import { ActivityModule } from './pages/activity/activity.module';

@NgModule({
  declarations: [AppComponent],
  imports: [SharedModule, RouterOutlet, ActivityModule, AuthModule, BrowserModule, RouterModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
