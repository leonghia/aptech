import { Component, ElementRef, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { SignupService } from '../signup-modal/signup.service';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.css']
})
export class LoginModalComponent implements OnInit {
  form: any = {
    username: null,
    password: null
  };

  isLoading: boolean = false;
  isLoggedIn: boolean = false;
  isLoginFailed: boolean = false;
  usernameInvalid: boolean = false;
  passwordInvalid: boolean = false;
  errorMessage: string = '';
  roles: string[] = [];

  errorFieldCSS: string = 'pr-10 border-red-300 text-red-900 placeholder-red-300 focus:outline-none focus:ring-red-500 focus:border-red-500';
  validFieldCSS: string = 'shadow-sm focus:ring-indigo-500 focus:border-indigo-500 border-gray-300';
  buttonLoadingCSS: string = 'py-2.5 px-5 mr-2 text-sm font-medium text-gray-900 bg-gray-300 rounded-md border border-transparent dark:bg-gray-800 dark:text-gray-400 dark:border-gray-600 dark:hover:text-white dark:hover:bg-gray-700 inline-flex justify-center w-full items-center';
  buttonNotLoadingCSS: string = 'inline-flex justify-center w-full rounded-md border border-transparent shadow-sm px-4 py-2 bg-indigo-600 text-base font-medium text-white hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 sm:text-sm';

  constructor(private loginService: LoginService, private signupService: SignupService, private authService: AuthService, private tokenStorage: TokenStorageService) { }

  ngOnInit(): void {
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
      this.roles = this.tokenStorage.getUser().roles;
    }
  }

  onCloseLoginModal() {
    this.loginService.closeLoginModal();
  }

  onOpenSignupModal() {
    this.loginService.closeLoginModal();
    this.signupService.openSignupModal();
  }

  onSubmit(): void {
    this.isLoading = true;
    const { username, password } = this.form;
    setTimeout(() => {
      this.authService.login(username, password).subscribe(data => {
        this.isLoading = false;
        this.loginService.closeLoginModal();
        this.tokenStorage.saveToken(data.accessToken);
        this.tokenStorage.saveUser(data);

        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.roles = this.tokenStorage.getUser().roles;
        this.reloadPage();
      },
        err => {
          this.isLoading = false;
          this.errorMessage = err.error.message;
          if (this.errorMessage.includes('User')) {
            this.usernameInvalid = true;
          }
          if (this.errorMessage.includes('Password')) {
            this.passwordInvalid = true;
          }
          this.isLoginFailed = true;
        }
      );
    }, 2000)

  }

  reloadPage(): void {
    window.location.reload();
  }

}
