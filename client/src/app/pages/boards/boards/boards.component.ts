import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-boards',
  templateUrl: './boards.component.html',
  styleUrls: ['./boards.component.scss'],
})
export class BoardsComponent implements OnInit {
  result: { communities: Community[]; pageNumber: number; isNext: boolean } | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private communityService: CommunityService,
  ) {}

  async ngOnInit() {
    const user = await this.authService.currentUser();
    if (!user) {
      return;
    }

    const userInfo = await this.authService.fetchUser(user.id);
    if (!userInfo?.onboarded) {
      this.redirect('/onboarding');
      return;
    }

    const searchParams = this.route.snapshot.queryParams;
    this.result = await this.communityService.fetchCommunities({
      searchString: searchParams.q,
      pageNumber: searchParams.page ? +searchParams.page : 1,
      pageSize: 25,
    });
  }

  private redirect(path: string) {
    this.router.navigate([path]);
  }
}
