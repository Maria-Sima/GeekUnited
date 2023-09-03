import { Component } from '@angular/core';

@Component({
  selector: 'app-auth-prism',
  templateUrl: './auth-prism.component.html',
  styleUrls: ['./auth-prism.component.scss']
})
export class AuthPrismComponent {
  prismTransform = 'translateZ(-100px)'; // Initial transform

  showLogin() {
    this.prismTransform = 'translateZ(-100px)';
  }

  showSignup() {
    this.prismTransform = 'translateZ(-100px) rotateY(-90deg)';
  }

  showForgotPassword() {
    this.prismTransform = 'translateZ(-100px) rotateY(-180deg)';
  }

  showSubscribe() {
    this.prismTransform = 'translateZ(-100px) rotateX(-90deg)';
  }

  showContactUs() {
    this.prismTransform = 'translateZ(-100px) rotateY(90deg)';
  }

  showThankYou() {
    this.prismTransform = 'translateZ(-100px) rotateX(90deg)';
  }
}
