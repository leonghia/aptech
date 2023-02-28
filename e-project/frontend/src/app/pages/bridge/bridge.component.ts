import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { fadeIn } from 'src/app/shared/animations';
import { ApiService } from 'src/app/shared/api.service';

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

  constructor(private route: ActivatedRoute, private apiService: ApiService) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.bridgeID = params['id'];
    });
    this.apiService.getBridges({ id: this.bridgeID}).subscribe((data: any) => {
      this.bridge = data;
    });
    this.apiService.getImages(this.bridgeID).subscribe(data => {
      this.bridgeImages = data;
      this.selectedImage = this.bridgeImages[0];
    });
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
  
}
