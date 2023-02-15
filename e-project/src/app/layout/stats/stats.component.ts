import { Component, EventEmitter, OnInit } from '@angular/core';
import { fadeRight } from 'src/app/shared/animations';

@Component({
  selector: 'app-stats',
  animations: [fadeRight],
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent implements OnInit {
  enterViewport: boolean = false;
  enteredViewport = new EventEmitter<void>();

  ngOnInit(): void {
    
  }

  onVisibilityChange(status: boolean): void {
    if (status) {
      this.enterViewport = status;
      this.enteredViewport.emit();
    }
  }

  animatedCounter(ceiling: number, interval: number): void {
    let counter = 0;
    const animatedCounterInterval = setInterval(() => {
      console.log(++counter);
      if (counter === ceiling)
        clearInterval(animatedCounterInterval);
    }, interval)
  }

  onEventFired() {
    console.log('Event Fired !');
  }

}
