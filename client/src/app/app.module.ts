import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { ParallaxComponent } from './components/parallax/parallax.component';
import { ScrollGalleryComponent } from './components/scroll-gallery/scroll-gallery.component';
import { FooterComponent } from './components/footer/footer.component';
import { AuthPrismComponent } from './components/auth-forms/auth-prism/auth-prism.component';
import { SubmitSuccessComponent } from './components/auth-forms/submit-success/submit-success.component';
import {FormsModule} from "@angular/forms";
import { AuthpageComponent } from './pages/authpage/authpage.component';
import { HomeComponent } from './pages/home/home.component';
import { TitleComponent } from './components/title/title.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    ParallaxComponent,
    ScrollGalleryComponent,
    FooterComponent,
    AuthPrismComponent,
    SubmitSuccessComponent,
    AuthpageComponent,
    HomeComponent,
    TitleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
