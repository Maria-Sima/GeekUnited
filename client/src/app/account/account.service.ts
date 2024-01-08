import { Injectable } from '@angular/core';

import { Observable, of, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

import { environment } from '../../environments/environment.prod';

import { IUser } from '../core/models/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;
  isLoggedIn$: Observable<boolean>;
  isLoggedOut$: Observable<boolean>;
  private currentUserSource = new ReplaySubject<IUser | null>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(
    private http: HttpClient,
    private router: Router,
  ) {
    this.isLoggedIn$ = this.currentUser$.pipe(map((user) => !!user));

    this.isLoggedOut$ = this.isLoggedIn$.pipe(map((loggedIn) => !loggedIn));

    const user = this.loadCurrentUser();
  }

  loadCurrentUser(): Observable<IUser | null> {
    let token = localStorage.getItem('token');
    if (token === null) {
      this.currentUserSource.next(null);
      return of<IUser | null>(null);
    }

    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get<IUser>(this.baseUrl + 'auth', { headers }).pipe(
      map((user: IUser) => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
        return user;
      }),
    );
  }

  login(values: any) {
    return this.http.post<IUser>(this.baseUrl + 'account/login', values).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      }),
    );
  }

  register(values: any) {
    return this.http.post<IUser>(this.baseUrl + 'Account/register', values).pipe(
      map((user: IUser) => {
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
