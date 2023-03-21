import { Component, EventEmitter, OnInit } from '@angular/core';
import { fadeRight } from 'src/app/animations/fade';

@Component({
  selector: 'app-stats',
  animations: [fadeRight],
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent implements OnInit {
  enterViewport: boolean = false;
  fadedDone: boolean = false;

  ngOnInit(): void {

  }

  onVisibilityChange(status: boolean): void {
    if (status)
      this.enterViewport = status;
  }

  animatedCounter(event: any, element: HTMLElement, ceiling: number, interval: number, sign: string): void {
    if (event.toState === 'faded') {
      this.fadedDone = true;
      let counter = 0;
      const animatedCounterInterval = setInterval(() => {
        element.innerHTML = ++counter + sign;
        if (counter === ceiling)
          clearInterval(animatedCounterInterval);
      }, interval)
    }

  }

}
