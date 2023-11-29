import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateThreadComponent } from './create-thread.component';
import { FormsModule } from '@angular/forms';
import { FormsComponentsModule } from '../../components/forms/forms-components.module';

@NgModule({
  declarations: [CreateThreadComponent],
  imports: [CommonModule, FormsModule, FormsComponentsModule],
})
export class CreateThreadModule {}
