import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorComponent } from './error/error.component';
import { ServerErrorComponent } from './error/server-error/server-error.component';
import { NotFoundComponent } from './error/not-found/not-found.component';
import { ErrorService } from './error/error.service';
import { LoadingService } from './loading/loading.service';

@NgModule({
  declarations: [ErrorComponent, ServerErrorComponent, NotFoundComponent],
  exports: [ErrorComponent],
  imports: [CommonModule],
  providers: [ErrorService, LoadingService],
})
export class CoreModule {}
