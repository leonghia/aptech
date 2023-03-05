import { Component, OnInit } from '@angular/core';
import { CompareService } from './compare.service';

@Component({
  selector: 'app-compare',
  templateUrl: './compare.component.html',
  styleUrls: ['./compare.component.css']
})
export class CompareComponent implements OnInit {
  bridges: any = [];

  constructor(private compareService: CompareService) {}

  ngOnInit(): void {
    this.compareService.comparedBridgesChanged.subscribe((bridges: any) => {
      this.bridges = bridges;
      console.log('bridge compare changed!');
    })
  }

  onCloseCompareModal() {
    this.compareService.closeCompareModal();
  }

  onClearComparison() {
    this.compareService.clearComparision();
  }
}
