import { Component, OnInit } from '@angular/core';
import { fadeRight, fadeLeft } from 'src/app/animations/fade';

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

  onVisibilityChangeTop(status: boolean): void {
    if (status)
      this.enterViewportTop = status;
  }

  onVisibilityChangeBottom(status: boolean): void {
    if (status)
      this.enterViewportBottom = status;
  }

}
