import { Component } from '@angular/core';

@Component({
  selector: 'app-bridge',
  templateUrl: './bridge.component.html',
  styleUrls: ['./bridge.component.css']
})
export class BridgeComponent {
  selectedTab: string = 'tab-info';

  onClickBtnTab(tab: string) {
    this.selectedTab = tab;
  }
}
