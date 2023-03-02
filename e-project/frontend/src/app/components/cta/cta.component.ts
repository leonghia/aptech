import { Component, OnInit } from '@angular/core';
import { fadeLeft } from 'src/app/animations/fade';
import { SignupService } from '../signup-modal/signup.service';

@Component({
  selector: 'app-cta',
  animations: [fadeLeft],
  templateUrl: './cta.component.html',
  styleUrls: ['./cta.component.css']
})
export class CtaComponent implements OnInit {
  enterViewport: boolean = false;

  constructor(private signupService: SignupService) {}

  ngOnInit(): void {
    
  }

  onVisibilityChange(status: boolean): void {
    if (status)
      this.enterViewport = status;
  }

  onOpenSignupModal() {
    this.signupService.openSignupModal();
  }
}
