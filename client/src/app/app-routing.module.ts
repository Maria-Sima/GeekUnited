import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ServerErrorComponent } from './core/error/server-error/server-error.component';
import { NotFoundComponent } from './core/error/not-found/not-found.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  { path: 'server-error', component: ServerErrorComponent, data: { breadcrumb: 'Server Error' } },
  { path: 'not-found', component: NotFoundComponent, data: { breadcrumb: 'Not Found' } },
  {
    path: 'boards',
    loadChildren: () => import('./boards/boards.module').then((mod) => mod.BoardsModule),
    data: { breadcrumb: 'Boards' },
  },
  {
    path: 'auth',
    loadChildren: () => import('./account/account.module').then((mod) => mod.AccountModule),
    data: { breadcrumb: 'Auth' },
  },
  {
    path: 'activity',
    canActivate: [AuthGuard],
    loadChildren: () => import('./activity/activity.module').then((mod) => mod.ActivityModule),
    data: { breadcrumb: 'Checkout' },
  },
  {
    path: 'post',
    canActivate: [AuthGuard],
    loadChildren: () => import('./post/post.module').then((mod) => mod.PostModule),
    data: { breadcrumb: 'Orders' },
  },
  {
    path: 'profile',
    loadChildren: () => import('./profile/profile.module').then((mod) => mod.ProfileModule),
    data: { breadcrumb: { skip: true } },
  },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
