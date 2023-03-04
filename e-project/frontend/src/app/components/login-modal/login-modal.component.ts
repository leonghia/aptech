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

  isLoggedIn: boolean = false;
  isLoginFailed: boolean = false;
  usernameInvalid: boolean = false;
  passwordInvalid: boolean = false;
  errorMessage: string = '';
  roles: string[] = [];

  errorFieldCSS: string = 'pr-10 border-red-300 text-red-900 placeholder-red-300 focus:outline-none focus:ring-red-500 focus:border-red-500';
  validFieldCSS: string = 'shadow-sm focus:ring-indigo-500 focus:border-indigo-500 border-gray-300';

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
    const { username, password } = this.form;

    this.authService.login(username, password).subscribe(data => {
        this.tokenStorage.saveToken(data.accessToken);
        this.tokenStorage.saveUser(data);

        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.roles = this.tokenStorage.getUser().roles;
        this.reloadPage();
      },
      err => {
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
  }

  reloadPage(): void {
    window.location.reload();
  }

}
