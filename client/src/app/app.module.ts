import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NavBarComponent} from './components/nav-bar/nav-bar.component';
import {ParallaxComponent} from './components/parallax/parallax.component';
import {FooterComponent} from './components/footer/footer.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {FormInputComponent} from './components/form-input/form-input.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule} from "@angular/material/button";
import {MatBottomSheetModule} from "@angular/material/bottom-sheet";
import {MatCardModule} from "@angular/material/card";
import {MatDialogModule} from "@angular/material/dialog";
import {MatIconModule} from "@angular/material/icon";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {HomeComponent} from "./pages/home/home.component";
import {TitleComponent} from "./components/title/title.component";
import {AuthenthicatorComponent} from "./pages/account/authenthicator/authenthicator.component";
import {LoginComponent} from "./pages/account/login/login.component";
import {RegisterComponent} from "./pages/account/register/register.component";
import {HttpClientModule} from "@angular/common/http";
import { CreatePostComponent } from './components/create-post/create-post.component';
import { PostFeedComponent } from './pages/post-feed/post-feed.component';
import { PostComponent } from './components/post/post.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ReplyComponent } from './components/reply/reply.component';
import { EmailVerificationComponent } from './pages/email-verification/email-verification.component';



@NgModule({
  declarations: [AppComponent,
    NavBarComponent,
    ParallaxComponent,
    FooterComponent,
LoginComponent,
    RegisterComponent,
    FormInputComponent,
    HomeComponent,
    TitleComponent,
    AuthenthicatorComponent,
    CreatePostComponent,
    PostFeedComponent,
    PostComponent,
    ProfileComponent,
    ReplyComponent,
    EmailVerificationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatBottomSheetModule,
    MatCardModule,
    MatDialogModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  exports: [FormInputComponent],
  bootstrap: [AppComponent]
})
export class AppModule {
}
