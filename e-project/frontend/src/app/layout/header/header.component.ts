import { Component, ElementRef, ViewChild, Renderer2, HostListener,OnInit ,} from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  topBarShown: boolean = true;
  mobileMenuStatus: boolean = false;

  constructor() {
    
  }

  ngOnInit(): void {
    
  }

  onDismissTopBar() {
    this.topBarShown = false;
  }

  onOpenMobileMenu() {
    this.mobileMenuStatus = true;
  }

  onCloseMobileMenu() {
    this.mobileMenuStatus = false;
  }

}

