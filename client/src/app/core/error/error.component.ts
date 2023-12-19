import { Component, OnInit } from '@angular/core';
import { ErrorService } from './error.service';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss'],
})
export class ErrorComponent implements OnInit {
  showErrors = false;

  errors$!: Observable<string[]>;

  constructor(public errorService: ErrorService) {
    console.log('Created error component');
  }

  ngOnInit() {
    this.errors$ = this.errorService.errors$.pipe(tap(() => (this.showErrors = true)));
  }

  onClose() {
    this.showErrors = false;
  }
}
