import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-onboarding',
  templateUrl: './onboarding.component.html',
  styleUrls: ['./onboarding.component.scss'],
})
export class OnboardingComponent implements OnInit {
  userData!: any;

  constructor(
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router,
  ) {}

  ngOnInit() {
    const userId = this.route.snapshot.paramMap.get('userId');

    this.authService.currentUser$.subscribe((userInfo) => {
      if (!userInfo || userInfo.onboarded) {
        this.router.navigate(['/']);
        return;
      }

      this.userData = {
        name: userInfo ? userInfo?.name : '',
        bio: userInfo ? userInfo?.bio : '',
        image: userInfo ? userInfo?.image : '',
      };
    });
  }
}
