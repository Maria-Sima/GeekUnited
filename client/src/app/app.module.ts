import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';

import { RouterModule, RouterOutlet } from '@angular/router';

import { AuthModule } from './auth/auth.module';
import { BrowserModule } from '@angular/platform-browser';
import { ActivityModule } from './pages/activity/activity.module';
import { CoreModule } from './core/core.module';

@NgModule({
  declarations: [AppComponent],
  imports: [SharedModule, RouterOutlet, ActivityModule, AuthModule, BrowserModule, RouterModule, CoreModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
