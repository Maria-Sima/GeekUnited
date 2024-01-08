import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent implements OnInit {
  user: any;
  userInfo: any;
  searchParams: any;
  result: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    // Add your actual services here
  ) {}

  async ngOnInit() {
    await this.initData();
  }

  async initData() {
    // this.user = await currentUser();
    // if (!this.user) return;
    //
    // this.userInfo = await fetchUser(this.user.id);
    // if (!this.userInfo?.onboarded) {
    //   redirect('/onboarding');
    //   return;
    // }
    //
    // this.searchParams = this.route.snapshot.data.searchParams;
    //
    // this.result = await fetchUsers({
    //   userId: this.user.id,
    //   searchString: this.searchParams.q,
    //   pageNumber: this.searchParams?.page ? +this.searchParams.page : 1,
    //   pageSize: 25,
    // });
  }
}
