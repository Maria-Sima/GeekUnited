import {Component, OnInit} from '@angular/core';
import {AccountService} from "../account.service";
import {ActivatedRoute, Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  returnUrl!: string;

  constructor(private accountService: AccountService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl'] || '/posts';
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required]),
      password: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    this.accountService.login(this.loginForm.value).subscribe({
      next:(response)=>this.router.navigateByUrl(this.returnUrl),
      error:(e)=>console.log(e)
    })
  }

}

