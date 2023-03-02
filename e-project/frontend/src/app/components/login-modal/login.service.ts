import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  loginModalStateChanged = new Subject<boolean>();
  constructor() { }

  openLoginModal() {
    this.loginModalStateChanged.next(true);
  }

  closeLoginModal() {
    this.loginModalStateChanged.next(false);
  }
}
