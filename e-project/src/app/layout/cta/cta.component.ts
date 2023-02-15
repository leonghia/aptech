import { Component } from '@angular/core';
import { fadeLeft } from 'src/app/shared/animations';

@Component({
  selector: 'app-cta',
  animations: [fadeLeft],
  templateUrl: './cta.component.html',
  styleUrls: ['./cta.component.css']
})
export class CtaComponent {
  enterViewport: boolean = false;

  onVisibilityChange(status: boolean): void {
    if (status)
      this.enterViewport = status;
  }
}
