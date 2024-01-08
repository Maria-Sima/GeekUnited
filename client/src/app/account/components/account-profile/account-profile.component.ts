import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IUser } from '../../../core/models/user';

@Component({
  selector: 'app-account-profile',
  templateUrl: './account-profile.component.html',
  styleUrls: ['./account-profile.component.scss'],
})
export class AccountProfileComponent implements OnInit {
  @Input() user!: IUser;
  @Input() btnTitle!: string;

  onboardForm!: FormGroup;
  files: File[] = [];

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.createOnboardForm();
  }

  createOnboardForm() {
    this.onboardForm = new FormGroup({
      profile_photo: new FormControl([this.user?.image || ''], [Validators.required]),
      name: new FormControl([this.user?.name || ''], [Validators.required]),
      username: new FormControl([this.user?.userName || ''], [Validators.required]),
      bio: new FormControl([this.user?.bio || ''], [Validators.required]),
    });
  }

  onSubmit(): void {
    const values = this.onboardForm.value;
    // Add your logic for handling form submission in Angular
  }

  handleImage(event: any): void {
    const file = event.target.files[0] as File;
    this.files = [file];

    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.onboardForm.patchValue({
        profile_photo: e.target.result,
      });
    };

    if (file) {
      reader.readAsDataURL(file);
    }
  }
}
