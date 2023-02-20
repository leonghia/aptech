import { Component,OnInit } from '@angular/core';
import { fadeRight, fadeLeft } from 'src/app/shared/animations';

@Component({
  selector: 'app-gallery',
  animations: [fadeRight, fadeLeft],
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit {
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
