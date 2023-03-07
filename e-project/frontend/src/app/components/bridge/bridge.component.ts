import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { fadeIn } from 'src/app/animations/fade';
import { BridgeService } from 'src/app/services/bridge.service';

// Import Swiper core and required modules
import SwiperCore, { SwiperOptions, Pagination } from 'swiper';
import { CompareService } from '../compare/compare.service';

// Install Swiper modules
SwiperCore.use([Pagination]);

@Component({
  selector: 'app-bridge',
  animations: [fadeIn],
  templateUrl: './bridge.component.html',
  styleUrls: ['./bridge.component.css']
})
export class BridgeComponent implements OnInit {
  @ViewChild('modal') modal!: ElementRef;
  @ViewChild('modalImg') modalImg!: ElementRef;
  selectedTab: string = 'tab-info';
  bridgeID!: string;
  bridge!: any;
  bridgeImages!: any[];
  selectedImage!: any;
  enterViewport: boolean = false;
  modalShown: boolean = false;

  config: SwiperOptions = {
    slidesPerView: 4,
    spaceBetween: 15,
    pagination: {
      clickable: true 
    },
  };

  constructor(private route: ActivatedRoute, private bridgeService: BridgeService, private compareService: CompareService, private sanitizer: DomSanitizer) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.bridgeID = params['id'];
      this.loadBridge(this.bridgeID);
      this.loadImages(this.bridgeID);
      this.enterViewport = false;
    });
  }

  loadBridge(bridgeId: string) {
    this.bridgeService.getBridges({id: bridgeId}).subscribe((data: any) => {
      this.bridge = data;
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

  onAddBridgeToCompare(bridge: any): void {
    this.compareService.addBridgeToComparison(bridge);
  }

}
