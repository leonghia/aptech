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

  removeBridgeFromComparison(bridgeToRemoved: any) {
    const bridgeToRemovedId = bridgeToRemoved.id;
    this.comparedBridges = this.comparedBridges.filter((bridge: any) => bridge.id !== bridgeToRemovedId);
    this.comparedBridgesChanged.next(this.comparedBridges.slice());
  }

  getComparedBridges() {
    return this.comparedBridges.slice();
  }

  closeCompareNoti() {
    this.compareNotiStateChanged.next(false);
  }

  clearComparision() {
    this.comparedBridges = [];
    this.comparedBridgesChanged.next(this.comparedBridges.slice());
    this.comparedBridgesLengthChanged.next(this.comparedBridges.length);
  }
}
