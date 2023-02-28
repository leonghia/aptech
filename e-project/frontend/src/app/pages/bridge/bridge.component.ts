import { Component, OnInit } from '@angular/core';
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
  selectedTab: string = 'tab-info';
  bridgeID!: string;
  bridge!: any;
  bridgeImages!: any[];
  selectedImage!: any;
  enterViewport: boolean = false;

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

  onVisibilityChange(status: boolean) {
    if (status)
      this.enterViewport = status;
  }

  onClickImage(image: any) {
    this.selectedImage = image;
  }

  onClickBtnTab(tab: string) {
    this.selectedTab = tab;
  }
  
}
