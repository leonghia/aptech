import { Component } from '@angular/core';

@Component({
  selector: 'app-review-modal',
  templateUrl: './review-modal.component.html',
  styleUrls: ['./review-modal.component.css']
})
export class ReviewModalComponent {
  currentText: string = '';
  rating: number = 0;

  onSelectRating(rating: number) {
    this.rating = rating;
  }
}
