import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompareService {
  compareNotiStateChanged = new Subject<boolean>();
  compareModalStateChanged = new Subject<boolean>();
  comparedBridgesChanged = new BehaviorSubject<any>([]);
  comparedBridgesLengthChanged = new Subject<number>();
  isNotified = new BehaviorSubject<{status: string, bridge?: string}>({status: '', bridge: undefined});
  private comparedBridges: any = [];
  longestBridge!: any;
  longestBridgeChanged = new BehaviorSubject<any>({});
  widestBridge!: any;
  widestBridgeChanged = new BehaviorSubject<any>({});
  highestBridge!: any;
  highestBridgeChanged = new BehaviorSubject<any>({});
  oldestBridge!: any;
  oldestBridgeChanged = new BehaviorSubject<any>({});

  constructor() { }

  openCompareModal() {
    this.compareModalStateChanged.next(true);
  }

  closeCompareModal() {
    this.compareModalStateChanged.next(false);
  }

  addBridgeToComparison(bridge: any) {
    this.compareNotiStateChanged.next(true);
    // Check if the comparison list has exceeded the maximum limit
    if (this.comparedBridges.length >= 5) {
      // If exceeded, emit an event isFull and quit
      this.isNotified.next({status: 'full'})
      return;
    }

    // Otherwise, check if the list contains duplicated bridge
    const duplicateBridge = this.comparedBridges.some((item: any) => item.id === bridge.id);
    // If duplicated is found, emit an event isDuplicated and quit
    if (duplicateBridge) {
      this.isNotified.next({status: 'duplicated', bridge: bridge.name});
      return;
    }

    // Otherwise, add the new bridge to the list
    this.comparedBridges.push(bridge);
    this.isNotified.next({status: 'added', bridge: bridge.name});
    this.comparedBridgesChanged.next(this.comparedBridges.slice());
    this.comparedBridgesLengthChanged.next(this.comparedBridges.length);
  }

  removeBridgeFromComparison(bridgeId: number) {
    this.comparedBridges = this.comparedBridges.filter((bridge: any) => bridge.id != bridgeId);
    this.comparedBridgesChanged.next(this.comparedBridges.slice());
    this.comparedBridgesLengthChanged.next(this.comparedBridges.length);
    if (this.comparedBridges.length === 0) {
      this.clearComparision();
    }
  }

  getComparedBridges() {
    return this.comparedBridges.slice();
  }

  compareBridges() {
    this.longestBridge = this.comparedBridges.reduce((prev: any, current: any) => {
      return (+prev.length > +current.length) ? prev: current
    });
    this.widestBridge = this.comparedBridges.reduce((prev: any, current: any) => {
      return (+prev.width > +current.width) ? prev : current
    });
    this.highestBridge = this.comparedBridges.reduce((prev: any, current: any) => {
      return (+prev.height > +current.height) ? prev : current
    });
    this.oldestBridge = this.comparedBridges.reduce((prev: any, current: any) => {
      return (new Date(prev.built_in) < new Date(current.built_in)) ? prev : current
    });
    this.longestBridgeChanged.next(this.longestBridge);
    this.widestBridgeChanged.next(this.widestBridge);
    this.highestBridgeChanged.next(this.highestBridge);
    this.oldestBridgeChanged.next(this.oldestBridge);
  }

  closeCompareNoti() {
    this.compareNotiStateChanged.next(false);
  }

  clearComparision() {
    this.comparedBridges = [];
    this.comparedBridgesChanged.next(this.comparedBridges.slice());
    this.comparedBridgesLengthChanged.next(this.comparedBridges.length);
    this.longestBridge = null;
    this.widestBridge = null;
    this.highestBridge = null;
    this.oldestBridge = null;
    this.longestBridgeChanged.next(this.longestBridge);
    this.widestBridgeChanged.next(this.widestBridge);
    this.highestBridgeChanged.next(this.highestBridge);
    this.oldestBridgeChanged.next(this.oldestBridge);
  }
}
