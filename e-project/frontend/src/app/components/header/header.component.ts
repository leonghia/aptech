import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { Subscription } from 'rxjs';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { filter } from 'rxjs';
import { CompareService } from '../compare/compare.service';
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
  profileDropdownMenuState: boolean = false;
  compareModalState: boolean = false;
  compareNotiState: boolean = false;
  comparisonLength: number = 0;
  favoriteLength: number = 0;
  private loginModalStateChangeSub!: Subscription;
  private signupModalStateChangeSub!: Subscription;
  private successModalStateChangeSub!: Subscription;
  private compareModalStateChangeSub!: Subscription;
  private comparisonLengthChangeSub!: Subscription;
  private compareNotiStateChangeSub!: Subscription;

  private roles: string[] = [];
  isLoggedIn: boolean = false;
  first_name?: string;
  last_name?: string;
  avatar?: string;
  isHomePage?: boolean;

  searchTerm!: string;

  constructor(private loginService: LoginService, private signupService: SignupService, private successService: SuccessService, private compareService: CompareService, private tokenStorageService: TokenStorageService, private router: Router) { }

  ngOnInit(): void {
    this.router.events
    .pipe(filter(event => event instanceof NavigationEnd))
    .subscribe((event: any) => {
      this.isHomePage = event.url === '/' || event.url === '';
    });
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
    this.successModalStateChangeSub = this.successService.successModalStateChanged.subscribe((state: boolean) => {
      this.successModalState = state;
    });
    this.compareModalStateChangeSub = this.compareService.compareModalStateChanged.subscribe((state: boolean) => {
      this.compareModalState = state;
    });
    this.comparisonLengthChangeSub = this.compareService.comparedBridgesLengthChanged.subscribe((length: number) => {
      this.comparisonLength = length;
    });
    this.compareService.compareNotiStateChanged.subscribe((state: boolean) => {
      this.compareNotiState = state;
    });
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

  openProfileDropdownMenu() {
    this.profileDropdownMenuState = !this.profileDropdownMenuState;
  }

  onOpenCompareModal () {
    this.compareService.openCompareModal();
  }

  logout(): void {
    this.tokenStorageService.signOut();
    window.location.reload();
  }

  onSubmit(searchTerm: string): void {
    this.router.navigate(['/search'], { queryParams: { q: searchTerm } });
    
  }

  ngOnDestroy(): void {
    this.loginModalStateChangeSub.unsubscribe();
    this.signupModalStateChangeSub.unsubscribe();
    this.successModalStateChangeSub.unsubscribe();
    this.compareModalStateChangeSub.unsubscribe();
    this.compareNotiStateChangeSub.unsubscribe();
  }

}

