import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SignupService {
  signupModalStateChanged = new Subject<boolean>();

  constructor() { }

  openSignupModal() {
    this.signupModalStateChanged.next(true);
  }

  closeSignupModal() {
    this.signupModalStateChanged.next(false);
  }
}
