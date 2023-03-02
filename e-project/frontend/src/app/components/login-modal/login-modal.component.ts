import { Component } from '@angular/core';
import { SignupService } from '../signup-modal/signup.service';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.css']
})
export class LoginModalComponent {

  constructor(private loginService: LoginService, private signupService: SignupService) {}

  onCloseLoginModal() {
    this.loginService.closeLoginModal();
  }

  onOpenSignupModal() {
    this.loginService.closeLoginModal();
    this.signupService.openSignupModal();
  }
}
