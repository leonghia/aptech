import { Component, OnInit } from '@angular/core';
import { fadeLeft } from 'src/app/shared/animations';

@Component({
  selector: 'app-cta',
  animations: [fadeLeft],
  templateUrl: './cta.component.html',
  styleUrls: ['./cta.component.css']
})
export class CtaComponent implements OnInit {
  enterViewport: boolean = false;

  ngOnInit(): void {
    
  }

  onVisibilityChange(status: boolean): void {
    if (status)
      this.enterViewport = status;
  }
}
