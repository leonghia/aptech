import { Component, OnInit } from '@angular/core';
import { fadeUp } from 'src/app/animations/fade';

@Component({
  selector: 'app-gradient-feature',
  animations: [fadeUp],
  templateUrl: './gradient-feature.component.html',
  styleUrls: ['./gradient-feature.component.css']
})
export class GradientFeatureComponent implements OnInit {
  enterViewport: boolean = false;
  ngOnInit(): void {
    
  }

  onVisibilityChange(status: boolean) {
    if (status)
      this.enterViewport = status;
  }
}
