import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ErrorComponent} from './error/error.component';
import {ServerErrorComponent} from './error/server-error/server-error.component';
import {NotFoundComponent} from './error/not-found/not-found.component';


@NgModule({
  declarations: [
    ErrorComponent,
    ServerErrorComponent,
    NotFoundComponent,

  ],
  imports: [
    CommonModule
  ]
})
export class CoreModule { }
