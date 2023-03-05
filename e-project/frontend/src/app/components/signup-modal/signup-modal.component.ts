import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
import { LoginService } from '../login-modal/login.service';
import { SuccessService } from '../success-modal/success.service';
import { SignupService } from './signup.service';

@Component({
  selector: 'app-signup-modal',
  templateUrl: './signup-modal.component.html',
  styleUrls: ['./signup-modal.component.css']
})
export class SignupModalComponent implements OnInit, OnDestroy {
  signupForm!: FormGroup;
  signupFormSubmitted!: boolean;
  errorFieldCSS: string = 'pr-10 border-red-300 text-red-900 placeholder-red-300 focus:outline-none focus:ring-red-500 focus:border-red-500';
  validFieldCSS: string = 'shadow-sm focus:ring-indigo-500 focus:border-indigo-500 border-gray-300';
  buttonLoadingCSS: string = 'py-2.5 px-5 mr-2 text-sm font-medium text-gray-900 bg-gray-300 rounded-md border border-transparent dark:bg-gray-800 dark:text-gray-400 dark:border-gray-600 dark:hover:text-white dark:hover:bg-gray-700 inline-flex justify-center w-full items-center';
  buttonNotLoadingCSS: string = 'inline-flex justify-center w-full rounded-md border border-transparent shadow-sm px-4 py-2 bg-indigo-600 text-base font-medium text-white hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 sm:text-sm';
  enteredPassword: string = '';
  isLoading!: boolean;
  successModalState: boolean = false;
  isSuccessful: boolean = false;
  isSignupFailed: boolean = false;
  errorMessage: string = '';
  usernameInUse!: boolean;
  emailInUse!: boolean;
  submittedUsername!: string;
  submittedEmail!: string;
  private successModalStateChangeSub!: Subscription;

  constructor(private signupService: SignupService, private loginService: LoginService, private authService: AuthService, private successService: SuccessService) { }

  ngOnInit(): void {
    this.signupForm = new FormGroup({
      'first_name': new FormControl(null, Validators.required),
      'last_name': new FormControl(null, Validators.required),
      'username': new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'password': new FormControl(null, [Validators.required, Validators.minLength(6), Validators.maxLength(20)]),
      'confirm_password': new FormControl(null, [Validators.required, this.confirmPassword.bind(this)]),
      'agree': new FormControl(false, Validators.requiredTrue)
    });
    this.successModalStateChangeSub = this.successService.successModalStateChanged.subscribe((state: boolean) => {
      this.successModalState = state;
    })
  }

  onCloseSignupModal() {
    this.signupService.closeSignupModal();
  }

  onOpenLoginModal() {
    this.signupService.closeSignupModal();
    this.loginService.openLoginModal();
  }

  touchedAndErrors(formControlName: string, errorName?: string): any {
    if (this.signupFormSubmitted) {
      if (errorName) {
        return this.signupForm.get(formControlName)?.errors && this.signupForm.get(formControlName)?.hasError(errorName);
      }
      return this.signupForm.get(formControlName)?.errors;
    } else {
      if (errorName) {
        return this.signupForm.get(formControlName)?.touched && this.signupForm.get(formControlName)?.errors && this.signupForm.get(formControlName)?.hasError(errorName);
      }
      return this.signupForm.get(formControlName)?.touched && this.signupForm.get(formControlName)?.errors;
    }

  }

  confirmPassword(control: FormControl): { [s: string]: boolean } | null {
    if (control.value && control.value !== this.enteredPassword) {
      return { 'passwordConfirmNotMatched': true }
    }
    return null;
  }

  onSubmit(): void {
    this.signupFormSubmitted = true;
    if (this.signupForm.valid) {
      this.isLoading = true;
      const first_name = this.signupForm.get('first_name')!.value;
      const last_name = this.signupForm.get('last_name')!.value;
      const username = this.signupForm.get('username')!.value;
      const email = this.signupForm.get('email')!.value;
      const password = this.signupForm.get('password')!.value;

      setTimeout(() => {
        this.authService.register(first_name, last_name, username, email, password).subscribe((data: any) => {
          this.isLoading = false;
          this.usernameInUse = false;
          this.emailInUse = false;
          this.isSuccessful = true;
          this.isSignupFailed = false;
          this.signupService.closeSignupModal();
          this.successService.openSuccessModal();
        }, (err: any) => {
          this.isLoading = false;
          this.errorMessage = err.error.message;
          if (this.errorMessage.includes('username')) {
            this.usernameInUse = true;
          }
          if (this.errorMessage.includes('email')) {
            this.emailInUse = true;
          }
          this.isSignupFailed = true;
          this.submittedUsername = username;
          this.submittedEmail = email;
        })
      }, 2000);
    }


  }

  ngOnDestroy(): void {
    this.successModalStateChangeSub.unsubscribe();
  }
}
