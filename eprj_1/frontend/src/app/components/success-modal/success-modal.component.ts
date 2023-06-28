import { Component } from '@angular/core';
import { SuccessService } from './success.service';

@Component({
  selector: 'app-success-modal',
  templateUrl: './success-modal.component.html',
  styleUrls: ['./success-modal.component.css']
})
export class SuccessModalComponent {
  
  constructor(private successService: SuccessService) {}

  onCloseSuccessModal() {
    this.successService.closeSuccessModal();
  }

}
