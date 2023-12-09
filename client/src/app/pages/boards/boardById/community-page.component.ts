import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-boardById',
  templateUrl: './community-page.component.html',
  styleUrls: ['./community-page.component.scss'],
})
export class CommunityPageComponent implements OnInit {
  user: any;
  communityDetails: CommunityDetails = {
    createdBy: { id: '', name: '', username: '' },
    name: '',
    username: '',
    image: '',
    bio: '',
    threads: [],
    members: [],
  }; // Adjust the type based on your CommunityDetails model
  communityTabs = [
    { label: 'Threads', value: 'threads', icon: '/assets/threads-icon.png' }, // Adjust the icon path
    { label: 'Members', value: 'members', icon: '/assets/members-icon.png' }, // Adjust the icon path
    { label: 'Requests', value: 'requests', icon: '/assets/requests-icon.png' }, // Adjust the icon path
  ];

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService,
    private communityService: CommunityService,
  ) {}

  async ngOnInit() {
    this.user = await this.authService.currentUser();
    if (!this.user) {
      return;
    }

    const communityId = this.route.snapshot.params.id;
    this.communityDetails = await this.communityService.fetchCommunityDetails(communityId);
  }
}
