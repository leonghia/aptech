import { Component, OnInit } from '@angular/core';
import { fadeRight, fadeLeft } from 'src/app/shared/animations';

@Component({
  selector: 'app-alternating-feature',
  animations: [fadeRight, fadeLeft],
  templateUrl: './alternating-feature.component.html',
  styleUrls: ['./alternating-feature.component.css']
})
export class AlternatingFeatureComponent implements OnInit {
  enterViewportTop: boolean = false;
  enterViewportBottom: boolean = false;

  ngOnInit(): void {
    
  }

  onVisibilityChangeTop(status: boolean) {
    this.enterViewportTop = status;
  }
  
  onVisibilityChangeBottom(status: boolean) {
    this.enterViewportBottom = status;
  }
}
