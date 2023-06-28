import { Component, OnInit } from '@angular/core';
import { CompareService } from '../compare.service';

@Component({
  selector: 'app-compare-noti',
  templateUrl: './compare-noti.component.html',
  styleUrls: ['./compare-noti.component.css']
})
export class CompareNotiComponent implements OnInit {
  bridgeNoti!: {
    status: string,
    bridge?: string
  };

  constructor(private compareService: CompareService) {}

  ngOnInit(): void {
    this.compareService.isNotified.subscribe((noti: {status: string, bridge?: string}) => {
      this.bridgeNoti = noti;
    })
  }

  onCloseCompareNoti() {
    this.compareService.closeCompareNoti();
  }
}
