import { Component, OnInit } from '@angular/core';
import * as AOS from 'aos';

@Component({
  selector: 'app-gradient-feature',
  templateUrl: './gradient-feature.component.html',
  styleUrls: ['./gradient-feature.component.css']
})
export class GradientFeatureComponent implements OnInit {
  ngOnInit(): void {
    AOS.init();
  }
}
