import { Component } from '@angular/core';
import { AuthenthicatorCompState } from './AuthenthicatorCompState';

@Component({
  selector: 'app-authenthicator',
  templateUrl: './authenthicator.component.html',
  styleUrls: ['./authenthicator.component.scss'],
})
export class AuthenthicatorComponent {
  state = AuthenthicatorCompState.LOGIN;

  getStateText() {
    switch (this.state) {
      case AuthenthicatorCompState.FORGOT_PASSWORD:
        return 'Forgot your password?';
      case AuthenthicatorCompState.REGISTER:
        return 'New here';
      case AuthenthicatorCompState.LOGIN:
        return 'Sign In';
    }
  }

  onSignIn() {
    this.state = AuthenthicatorCompState.LOGIN;
  }

  onForgotPassword() {
    this.state = AuthenthicatorCompState.FORGOT_PASSWORD;
  }

  onCreateAccount() {
    this.state = AuthenthicatorCompState.REGISTER;
  }

  isLoginState() {
    return this.state == AuthenthicatorCompState.LOGIN;
  }

  isRegisterState() {
    return this.state == AuthenthicatorCompState.REGISTER;
  }

  isForgotPasswordState() {
    return this.state == AuthenthicatorCompState.FORGOT_PASSWORD;
  }
}
