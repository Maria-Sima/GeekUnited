import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject, catchError, Observable, of, throwError } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { IPost } from '../../core/models/post';
import { Params } from '../../core/models/params';
import { IPagination, Pagination } from '../../core/models/pagination';
import { LoadingService } from '../../core/loading/loading.service';
import { ErrorService } from '../../core/error/error.service';

@Injectable({
  providedIn: 'root',
})
export class PostsService {
  baseUrl = 'https://localhost:5001/api/';
  pagination = new Pagination();
  params = new Params();
  private postsSubject = new BehaviorSubject<IPost[]>([]);
  posts$: Observable<IPost[]> = this.postsSubject.asObservable();

  private paginationSubject = new BehaviorSubject<Pagination | null>(null);
  pagination$: Observable<Pagination | null> = this.paginationSubject.asObservable();

  constructor(
    private http: HttpClient,
    private loading: LoadingService,
    private errors: ErrorService,
  ) {}

  getParams() {
    return this.params;
  }

  setParams(params: Params) {
    this.params = params;
  }

  getPost(id: string) {
    const post = this.postsSubject.value.find((p) => p.id === id);

    if (post) {
      return of(post);
    }

    return this.http.get<IPost>(this.baseUrl + 'posts/' + id);
  }

  private loadPosts(id: string): Observable<IPagination | null> {
    if (this.postsSubject.value.length > 0) {
      const pagesReceived = Math.ceil(this.postsSubject.value.length / this.params.pageSize);

      if (this.params.pageNumber <= pagesReceived) {
        this.pagination.data = this.postsSubject.value.slice(
          (this.params.pageNumber - 1) * this.params.pageSize,
          this.params.pageNumber * this.params.pageSize,
        );

        return of(this.pagination);
      }
    }

    let params = new HttpParams();

    if (this.params.boardId !== 0) {
      params = params.append('brandId', this.params.boardId.toString());
    }

    if (this.params.userId !== 0) {
      params = params.append('typeId', this.params.userId.toString());
    }

    if (this.params.search) {
      params = params.append('search', this.params.search);
    }

    params = params.append('sort', this.params.sort);
    params = params.append('pageIndex', this.params.pageNumber.toString());
    params = params.append('pageSize', this.params.pageSize.toString());

    return this.http
      .get<IPagination>(this.baseUrl + 'posts', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          const newPosts = response.body ? response.body.data : [];
          this.postsSubject.next([...this.postsSubject.value, ...newPosts]);
          this.paginationSubject.next(response.body);
          return response.body;
        }),
        catchError((err) => {
          const message = 'Could not load posts';
          this.errors.showErrors(message);
          console.log(message, err);
          return throwError(err);
        }),
        tap(this.loading.showLoaderUntilCompleted(this.posts$).subscribe()),
      );
  }
}
