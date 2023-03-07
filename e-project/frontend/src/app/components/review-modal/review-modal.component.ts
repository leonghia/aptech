import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { ReviewService } from 'src/app/services/review.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { ReviewModalService } from './review-modal.service';

@Component({
  selector: 'app-review-modal',
  templateUrl: './review-modal.component.html',
  styleUrls: ['./review-modal.component.css']
})
export class ReviewModalComponent implements OnInit {

  user_id!: number;
  bridge_id!: number;
  rating: number = 0;
  content: string = '';
  review_title!: string;

  isLoading: boolean = false;

  buttonLoadingCSS: string = 'inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-gray-900 bg-gray-300 focus:outline-none'
  buttonNotLoadingCSS: string = 'inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-indigo-600 disabled:bg-indigo-400 hover:bg-indigo-700 focus:outline-none';

  isLoggedIn: boolean = false;
  avatar?: string;
  

  constructor(private tokenStorageService: TokenStorageService, private reviewModalService: ReviewModalService, private route: ActivatedRoute, private reviewService: ReviewService) {}

  ngOnInit(): void {
    this.isLoggedIn = !!this.tokenStorageService.getToken();
    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();
      this.avatar = user.avatar;
      this.user_id = user.id;
    };
    this.route.params.subscribe((params: Params) => {
      this.bridge_id = params['id'];
    })
  }
  
  onSelectRating(rating: number) {
    this.rating = rating;
  }

  onCloseReviewModal() {
    this.reviewModalService.closeReviewModal();
  }

  onSubmit() {
    this.isLoading = true;
    setTimeout(() => {
      this.reviewService.postReview(this.user_id, this.bridge_id, this.rating, this.content, this.review_title).subscribe(data => {
        this.isLoading = false;
        this.reloadPage();
      }, err => {
        this.isLoading = false;
        this.reloadPage();
      })
    }, 2000)
  }

  reloadPage(): void {
    window.location.reload();
  }
}
