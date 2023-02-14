import { Component, OnInit } from '@angular/core';
import * as AOS from 'aos';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent implements OnInit {
  ngOnInit(): void {
    AOS.init();
  }

  _visibilityChangeHandler(event: string) {
    console.log(event);
  }
  
}
