import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss'],
})
export class AddPostComponent implements OnInit {
  userId: string = '';
  organization: any;

  postThreadForm!: FormGroup;

  constructor(
    private router: Router,
    // private organizationService: OrganizationService,
    private fb: FormBuilder,
  ) {}

  ngOnInit(): void {
    this.userId = 'yourUserId'; // Replace with the actual user.ts ID
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
      // Example: this.organizationService.createThread(values.post, this.userId, this.organization?.id, '/');

      this.router.navigate(['/']);
    }
  }
}
