import { AfterViewInit, Directive, ElementRef, EventEmitter, OnDestroy, Output, Host } from '@angular/core';

@Directive({
  selector: '[enterTheViewportNotifier]'
})
export class EnterTheViewportNotifierDirective implements AfterViewInit, OnDestroy {
  @Output() visibilityChange = new EventEmitter<boolean>();
  private _observer!: IntersectionObserver;

  constructor(@Host() private _elementRef: ElementRef) { }

  // Define the observer and subscribe host element to the observer
  ngAfterViewInit(): void {
    const options = {root: null, rootMargin: '0px', threshold: 0.6};
    this._observer = new IntersectionObserver(this._callback, options);
    this._observer.observe(this._elementRef.nativeElement);
  }

  // Unsubscribe the observer to avoid memory leak
  ngOnDestroy(): void {
    this._observer.disconnect();
  }

  // Emit an event holding boolean value when the element enters the viewport
  private _callback = (entries: any) => {
    entries.forEach((entry: any) =>
      this.visibilityChange.emit(entry.isIntersecting ? true : false));
  }

}
