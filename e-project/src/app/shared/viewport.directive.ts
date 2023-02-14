import { AfterViewInit, Directive, ElementRef, EventEmitter, OnDestroy, Output, Host } from '@angular/core';

@Directive({
  selector: '[enterTheViewportNotifier]'
})
export class EnterTheViewportNotifierDirective implements AfterViewInit, OnDestroy {
  @Output() visibilityChange = new EventEmitter<'VISIBLE' | 'HIDDEN'>();
  private _observer!: IntersectionObserver;

  constructor(@Host() private _elementRef: ElementRef) { }

  ngAfterViewInit(): void {
    const options = {root: null, rootMargin: '0px', threshold: 0.0};
    this._observer = new IntersectionObserver(this._callback, options);
    this._observer.observe(this._elementRef.nativeElement);
  }

  ngOnDestroy(): void {
    this._observer.disconnect();
  }

  private _callback = (entries: any) => {
    entries.forEach((entry: any) => 
      this.visibilityChange.emit(entry.isIntersecting ? 'VISIBLE' : 'HIDDEN'));
  }

}
