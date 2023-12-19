import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { IPost } from '../core/models/post';
import { map, shareReplay } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(
    private http: HttpClient,
    private router: Router,
    private auth: AuthService,
  ) {}

  getUserPosts(userId: string): Observable<IPost[]> {
    return this.http.get<IPost[]>(this.baseUrl + 'posts/' + userId).pipe(
      map((response) => {
        return response;
      }),
      shareReplay(),
    );
  }

  getUsers(): Observable<IPost[]> {
    return this.http.get<IPost[]>(this.baseUrl + 'posts/').pipe(
      map((response) => {
        return response;
      }),
      shareReplay(),
    );
  }

  getActivity(userId: string): Observable<IPost[]> {
    return this.http.get<IPost[]>(this.baseUrl + 'posts/' + userId).pipe(
      map((response) => {
        return response;
      }),
      shareReplay(),
    );
  }
}
