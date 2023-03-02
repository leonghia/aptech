import { Component } from '@angular/core';
import { LoginService } from '../login-modal/login.service';
import { SignupService } from './signup.service';

@Component({
  selector: 'app-signup-modal',
  templateUrl: './signup-modal.component.html',
  styleUrls: ['./signup-modal.component.css']
})
export class SignupModalComponent {

  constructor(private signupService: SignupService, private loginService: LoginService) {}

  onCloseSignupModal() {
    this.signupService.closeSignupModal();
  }

  onOpenLoginModal() {
    this.signupService.closeSignupModal();
    this.loginService.openLoginModal();
  }
}
