import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CompareService } from './compare.service';

@Component({
  selector: 'app-compare',
  templateUrl: './compare.component.html',
  styleUrls: ['./compare.component.css']
})
export class CompareComponent implements OnInit, OnDestroy {
  bridges: any = [];
  longestBridge!: any;
  widestBridge!: any;
  highestBridge!: any;
  oldestBridge!: any;
  isLoading: boolean = false;
  buttonLoadingCSS: string = 'inline-flex items-center px-5 py-2 border border-transparent text-xs font-medium rounded-md shadow-sm text-gray-900 bg-gray-300';
  buttonIsNotLoadingCSS: string = 'inline-flex items-center px-5 py-2 border border-transparent text-xs font-medium rounded-md shadow-sm text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none';

  comparedBridgesChangedSub!: Subscription;
  longestBridgeChangedSub!: Subscription;
  widestBridgeChangedSub!: Subscription;
  highestBridgeChangedSub!: Subscription;
  oldestBridgeChangedSub!: Subscription;

  constructor(private compareService: CompareService) {}

  ngOnInit(): void {
    this.longestBridgeChangedSub = this.compareService.longestBridgeChanged.subscribe((bridge: any) => {
      this.longestBridge = bridge;
    })
    this.widestBridgeChangedSub = this.compareService.widestBridgeChanged.subscribe((bridge: any) => {
      this.widestBridge = bridge;
    })
    this.highestBridgeChangedSub = this.compareService.highestBridgeChanged.subscribe((bridge: any) => {
      this.highestBridge = bridge;
    })
    this.oldestBridgeChangedSub = this.compareService.oldestBridgeChanged.subscribe((bridge: any) => {
      this.oldestBridge = bridge;
    })
    this.comparedBridgesChangedSub = this.compareService.comparedBridgesChanged.subscribe((bridges: any) => {
      this.bridges = bridges;
    })
  }

  onCloseCompareModal() {
    this.compareService.closeCompareModal();
  }

  onCompareBridges() {
    this.isLoading = true;
    setTimeout(() => {
      this.compareService.compareBridges();
      this.isLoading = false;
    }, 1500);
    
  }

  onDeleteBridge(bridgeId: number) {
    this.compareService.removeBridgeFromComparison(bridgeId);
  }

  onClearComparison() {
    this.compareService.clearComparision();
  }

  ngOnDestroy(): void {
    console.log(this.longestBridge);
    this.comparedBridgesChangedSub.unsubscribe();
    this.longestBridgeChangedSub.unsubscribe();
    this.widestBridgeChangedSub.unsubscribe();
    this.highestBridgeChangedSub.unsubscribe();
    this.oldestBridgeChangedSub.unsubscribe();
  }

}
