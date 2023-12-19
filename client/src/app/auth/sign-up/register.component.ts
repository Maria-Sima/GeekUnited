import { Component, OnInit } from '@angular/core';
import { AsyncValidatorFn, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map, of, switchMap, timer } from 'rxjs';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  errors: string[] = [];

  constructor(
    private fb: FormBuilder,
    private accountService: AuthService,
    private router: Router,
  ) {}

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      displayName: [null, [Validators.required]],
      email: [null, [Validators.required], [this.validateEmailNotTaken()]],
      password: [null, [Validators.required]],
    });
  }

  onSubmit() {
    this.accountService.register(this.registerForm.value).subscribe({
      next: (response) => this.router.navigateByUrl('/posted'),
      error: (e) => {
        console.log(e);
        this.errors = e.errors;
      },
    });
  }

  validateEmailNotTaken(): AsyncValidatorFn {
    return (control) => {
      return timer(500).pipe(
        switchMap(() => {
          if (!control.value) {
            return of(null);
          }
          return this.accountService.checkEmailExists(control.value).pipe(
            map((res) => {
              return res ? { emailExists: true } : null;
            }),
          );
        }),
      );
    };
  }
}
