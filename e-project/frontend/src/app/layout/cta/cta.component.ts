import { Component, OnInit, AfterViewInit } from '@angular/core';
import { fadeLeft } from 'src/app/shared/animations';

declare var window: any;

@Component({
  selector: 'app-cta',
  animations: [fadeLeft],
  templateUrl: './cta.component.html',
  styleUrls: ['./cta.component.css']
})
export class CtaComponent implements OnInit, AfterViewInit {
  enterViewport: boolean = false;


  ngOnInit(): void {
    
  }

  ngAfterViewInit(): void {
    if (window.FlowBite) {
      window.FlowBite.init();
    }
  }

  onVisibilityChange(status: boolean): void {
    if (status)
      this.enterViewport = status;
  }
}
