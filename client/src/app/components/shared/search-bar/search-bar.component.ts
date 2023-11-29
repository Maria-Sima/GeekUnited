import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {debounceTime, distinctUntilChanged, Subject, takeUntil} from "rxjs";
import {Router} from "@angular/router";

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchbarComponent implements OnInit, OnDestroy {
  @Input() routeType: string = '';
  search: string = '';
  private destroy$ = new Subject<void>();
  private search$ = new Subject<string>();

  constructor(private router: Router) {}

  ngOnInit() {
    this.watchSearch();
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  private watchSearch() {
    this.search$.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      takeUntil(this.destroy$)
    ).subscribe((search) => {
      this.handleSearch(search);
    });
  }

  updateSearchTerm(term: string) {
    this.search$.next(term);
  }

  handleSearch(search: string) {
    if (search) {
      this.router.navigate([`/${this.routeType}`], { queryParams: { q: search } });
    } else {
      this.router.navigate([`/${this.routeType}`]);
    }
  }
}
