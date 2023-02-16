import { Component, OnInit } from '@angular/core';
import { fadeRight, fadeLeft } from 'src/app/shared/animations';
@Component({
  selector: 'app-gallery2',
  templateUrl: './gallery2.component.html',
  styleUrls: ['./gallery2.component.css']
})
export class Gallery2Component implements OnInit {
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
