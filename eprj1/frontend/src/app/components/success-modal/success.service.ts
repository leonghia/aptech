import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SuccessService {
  successModalStateChanged = new Subject<boolean>();

  constructor() { }

  openSuccessModal() {
    this.successModalStateChanged.next(true);
  }

  closeSuccessModal() {
    this.successModalStateChanged.next(false);
  }
}
