import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReviewModalService {
  reviewModalStateChanged = new Subject<boolean>();

  constructor() { }

  openReviewModal() {
    this.reviewModalStateChanged.next(true);
  }

  closeReviewModal() {
    this.reviewModalStateChanged.next(false);
  }
}
