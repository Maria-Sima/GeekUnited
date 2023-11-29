import { NgModule } from '@angular/core';
import {ActivatedRoute, RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./home/home/home.component";
import {PostFeedComponent} from "./posts/post-feed/post-feed.component";
import {NotFoundComponent} from "./core/error/not-found/not-found.component";
import {ServerErrorComponent} from "./core/error/server-error/server-error.component";



const routes: Routes = [
  { path: '', component: HomeComponent, data: { breadcrumb: 'Home' } },
  { path: 'server-error', component: ServerErrorComponent, data: { breadcrumb: 'Server Error' } },
  { path: 'not-found', component: NotFoundComponent, data: { breadcrumb: 'Not Found' } },
  {path:'post-feed',component:PostFeedComponent,data:{ breadcrumb:'Postfeed'}}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
