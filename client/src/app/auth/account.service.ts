import { Injectable } from '@angular/core';

import { Observable, of, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { UserResponse } from '../core/models/UserResponse';
import { environment } from '../../environments/environment.prod';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<UserResponse | null>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(
    private http: HttpClient,
    private router: Router,
  ) {}

  loadCurrentUser(token: string): Observable<UserResponse | null> {
    if (token === null) {
      this.currentUserSource.next(null);
      return of<UserResponse | null>(null);
    }

    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get<UserResponse>(this.baseUrl + 'account', { headers }).pipe(
      map((user: UserResponse) => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
        return user;
      }),
    );
  }

  login(values: any) {
    return this.http.post<UserResponse>(this.baseUrl + 'account/login', values).pipe(
      map((user: UserResponse) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      }),
    );
  }

  register(values: any) {
    console.log(this.baseUrl + 'Account/sign-up');
    return this.http.post<UserResponse>(this.baseUrl + 'Account/register', values).pipe(
      map((user: UserResponse) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      }),
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  checkEmailExists(email: string) {
    return this.http.get(this.baseUrl + 'account/emailexists?email=' + email);
  }
}
