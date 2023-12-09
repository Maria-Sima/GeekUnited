import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { sidebarLinks } from '../../utils/constants';
import { AccountService } from '../../auth/account.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-left-side-bar',
  templateUrl: './left-side-bar.component.html',
  styleUrls: ['./left-side-bar.component.scss'],
})
export class LeftSideBarComponent {
  sidebarLinks = sidebarLinks;

  constructor(
    private router: Router,
    private accountService: AccountService,
  ) {}

  isActive(route: string): boolean {
    const currentRoute = this.router.url;
    return (currentRoute.includes(route) && route.length > 1) || currentRoute === route;
  }

  navigateToProfile(): void {
    const userId = this.accountService.currentUser$.pipe(map((user) => user?.id));
    this.router.navigate(['/profile', userId]);
  }

  signOut(): void {
    this.accountService.logout();
    this.router.navigate(['/sign-in']);
  }
}
