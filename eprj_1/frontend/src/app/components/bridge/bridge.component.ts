import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { fadeIn } from 'src/app/animations/fade';
import { BridgeService } from 'src/app/services/bridge.service';
import { FavoritesService } from 'src/app/services/favorites.service';
import { ReviewService } from 'src/app/services/review.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';

// Import Swiper core and required modules
import SwiperCore, { SwiperOptions, Pagination } from 'swiper';
import { CompareService } from '../compare/compare.service';
import { LoginService } from '../login-modal/login.service';
import { ReviewModalService } from '../review-modal/review-modal.service';

// Install Swiper modules
SwiperCore.use([Pagination]);

@Component({
  selector: 'app-bridge',
  animations: [fadeIn],
  templateUrl: './bridge.component.html',
  styleUrls: ['./bridge.component.css']
})
export class BridgeComponent implements OnInit, OnDestroy {
  @ViewChild('modal') modal!: ElementRef;
  @ViewChild('modalImg') modalImg!: ElementRef;
  selectedTab: string = 'tab-info';
  bridgeID!: string;
  bridge!: any;
  bridgeImages!: any[];
  selectedImage!: any;
  enterViewport: boolean = false;
  modalShown: boolean = false;

  reviews?: any[];

  one_star_width_percent!: number;
  two_star_width_percent!: number;
  three_star_width_percent!: number;
  four_star_width_percent!: number;
  five_star_width_percent!: number;

  reviewModalState: boolean = false;
  reviewModalStateChangeSub!: Subscription;

  isLoggedIn!: boolean;
  user_id!: number;

  config: SwiperOptions = {
    slidesPerView: 4,
    spaceBetween: 15,
    pagination: {
      clickable: true 
    },
  };

  constructor(private route: ActivatedRoute, private bridgeService: BridgeService, private compareService: CompareService, private sanitizer: DomSanitizer, private tokenStorageService: TokenStorageService, private reviewModalService: ReviewModalService, private loginService: LoginService, private reviewService: ReviewService, private favoritesService: FavoritesService) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.bridgeID = params['id'];
      this.loadBridge(this.bridgeID);
      this.loadImages(this.bridgeID);
      this.enterViewport = false;
    });

    this.isLoggedIn = !!this.tokenStorageService.getToken();
    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();
      this.user_id = user.id;
    };

    this.reviewModalStateChangeSub = this.reviewModalService.reviewModalStateChanged.subscribe((state: boolean) => {
      this.reviewModalState = state;
    });

    this.reviewService.getReviews(this.bridgeID).subscribe((data: any[]) => {
      this.reviews = data;
    })
  }

  loadBridge(bridgeId: string) {
    this.bridgeService.getBridges({id: bridgeId}).subscribe((data: any) => {
      this.bridge = data;
      this.one_star_width_percent = data.one_star_reviews ? +data.one_star_reviews / data.review_count : 0;
      this.two_star_width_percent = data.two_star_reviews ? +data.two_star_reviews / data.review_count : 0;
      this.three_star_width_percent = data.three_star_reviews ? +data.three_star_reviews / data.review_count : 0;
      this.four_star_width_percent = data.four_star_reviews ? +data.four_star_reviews / data.review_count : 0;
      this.five_star_width_percent = data.five_star_reviews ? +data.five_star_reviews / data.review_count : 0;
      this.bridge.map = this.getSafeUrl(this.bridge.map);
    })
  }

  getSafeUrl(url: string): any {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }

  loadImages(bridgeId: string) {
    this.bridgeService.getImages(bridgeId).subscribe((data: any[]) => {
      this.bridgeImages = data;
      this.selectedImage = this.bridgeImages[0];
    })
  }

  onVisibilityChange(status: boolean): void {
    if (status)
      this.enterViewport = status;
  }

  onClickImage(image: any): void {
    this.selectedImage = image;
  }

  onClickBtnTab(tab: string): void {
    this.selectedTab = tab;
  }

  onShowModal(modalSrc: string): void {
    this.modalShown = true;
    this.modal.nativeElement.classList.remove('hidden');
    this.modalImg.nativeElement.src = modalSrc;
  }

  onCloseModal(): void {
    this.modalShown = false;
    this.modal.nativeElement.classList.add('hidden');
  }

  onAddBridgeToComparison(bridge: any): void {
    this.compareService.addBridgeToComparison(bridge);
  }

  onAddBridgeToFavorites(bridge_id: number | string, bridgeName: string): void {
    this.favoritesService.addFavorite(this.user_id, bridge_id, bridgeName)!.subscribe(data => {

    }, err => {
      
    })
  }

  onHitTheWriteReviewBtn() {
    if (this.isLoggedIn) {
      this.reviewModalService.openReviewModal();
      this.selectedTab = 'tab-reviews';
    } else {
      this.loginService.openLoginModal();
    }
  }

  ngOnDestroy(): void {
    this.reviewModalStateChangeSub.unsubscribe();
  }

}
