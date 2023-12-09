import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { sidebarLinks } from '../../utils/constants';

@Component({
  selector: 'app-bottom-bar',
  templateUrl: './bottom-bar.component.html',
  styleUrls: ['./bottom-bar.component.scss'],
})
export class BottomBarComponent {
  sidebarLinks = sidebarLinks; // Assuming you have a constant or service providing the sidebarLinks

  constructor(private router: Router) {}

  isActive(route: string): boolean {
    const currentRoute = this.router.url;
    return (currentRoute.includes(route) && route.length > 1) || currentRoute === route;
  }
}
