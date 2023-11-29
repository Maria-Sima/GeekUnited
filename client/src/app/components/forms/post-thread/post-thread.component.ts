import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post-thread',
  templateUrl: './post-thread.component.html',
  styleUrls: ['./post-thread.component.scss'],
})
export class PostThreadComponent implements OnInit {
  userId: string = '';
  organization: any;

  postThreadForm!: FormGroup;

  constructor(
    private router: Router,
    // private organizationService: OrganizationService,
    private fb: FormBuilder,
  ) {}

  ngOnInit(): void {
    this.userId = 'yourUserId'; // Replace with the actual user ID
    // this.organization = this.organizationService.getOrganization(); // Adjust based on your organization service method

    this.postThreadForm = this.fb.group({
      thread: ['', Validators.required],
      accountId: [this.userId],
    });
  }

  onSubmit() {
    if (this.postThreadForm.valid) {
      const values = this.postThreadForm.value;

      // Call your createThread function here
      // Adjust the method based on your organization service method and createThread function
      // Example: this.organizationService.createThread(values.thread, this.userId, this.organization?.id, '/');

      this.router.navigate(['/']);
    }
  }
}
