import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoginService } from '../login-modal/login.service';
import { SignupService } from '../signup-modal/signup.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {
  topBarShown: boolean = true;
  mobileMenuStatus: boolean = false;
  loginModalState: boolean = false;
  signupModalState: boolean = false;
  private loginModalStateChangeSub!: Subscription;
  private signupModalStateChangeSub!: Subscription;

  constructor(private loginService: LoginService, private signupService: SignupService) {}

  ngOnInit(): void {
    this.loginModalStateChangeSub = this.loginService.loginModalStateChanged.subscribe((state: boolean) => {
      this.loginModalState = state;
    });
    this.signupModalStateChangeSub = this.signupService.signupModalStateChanged.subscribe((state: boolean) => {
      this.signupModalState = state;
    })
  }

  onDismissTopBar() {
    this.topBarShown = false;
  }

  onOpenMobileMenu() {
    this.mobileMenuStatus = true;
  }

  onCloseMobileMenu() {
    this.mobileMenuStatus = false;
  }

  onOpenLoginModal() {
    this.loginService.openLoginModal();
  }

  onOpenSignupModal() {
    this.signupService.openSignupModal();
  }

  ngOnDestroy(): void {
    this.loginModalStateChangeSub.unsubscribe();
    this.signupModalStateChangeSub.unsubscribe();
  }

}

