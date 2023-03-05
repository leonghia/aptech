import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { LoginService } from '../login-modal/login.service';
import { SignupService } from '../signup-modal/signup.service';
import { SuccessService } from '../success-modal/success.service';

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
  successModalState: boolean = false;
  private loginModalStateChangeSub!: Subscription;
  private signupModalStateChangeSub!: Subscription;
  private successModalStateChangeSub!: Subscription;

  private roles: string[] = [];
  isLoggedIn: boolean = false;
  first_name?: string;
  last_name?: string;
  avatar?: string;

  constructor(private loginService: LoginService, private signupService: SignupService, private successService: SuccessService, private tokenStorageService: TokenStorageService) { }

  ngOnInit(): void {
    this.isLoggedIn = !!this.tokenStorageService.getToken();

    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();
      this.roles = user.roles;

      this.first_name = user.first_name;
      this.last_name = user.last_name;
      this.avatar = user.avatar;
    }

    this.loginModalStateChangeSub = this.loginService.loginModalStateChanged.subscribe((state: boolean) => {
      this.loginModalState = state;
    });
    this.signupModalStateChangeSub = this.signupService.signupModalStateChanged.subscribe((state: boolean) => {
      this.signupModalState = state;
    });
    this.successModalStateChangeSub = this.successService.successModalStateChanged.subscribe((status: boolean) => {
      this.successModalState = status;
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

  logout(): void {
    this.tokenStorageService.signOut();
    window.location.reload();
  }

  ngOnDestroy(): void {
    this.loginModalStateChangeSub.unsubscribe();
    this.signupModalStateChangeSub.unsubscribe();
    this.successModalStateChangeSub.unsubscribe();
  }

}

