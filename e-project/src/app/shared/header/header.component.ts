import { Component, ElementRef, ViewChild, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  @ViewChild('featuresMenuBtn') featuresMenuBtn!: ElementRef;
  @ViewChild('featuresMenu') featuresMenu!: ElementRef;
  featuresMenuToggled: boolean = false;

  constructor(private renderer: Renderer2) {
    /**
     * This events get called by all clicks on the page
     */
    this.renderer.listen('window', 'click', (e: Event) => {
      /**
       * Only run when featuresMenuButton is not clicked
       * If we don't check this, all clicks (even on the button) gets into this
       * section which in the result we might never see the feature menu open!
       * And the menu itself is checked here, and it's where we check just outside of
       * the menu and button the condition above must close the menu
       */
      if (e.target !== this.featuresMenuBtn.nativeElement)
        this.featuresMenuToggled = false;
    });
  }

  onClickFeaturesMenu() {
    this.featuresMenuToggled = !this.featuresMenuToggled;
  }
}
