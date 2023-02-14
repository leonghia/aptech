import { Component, OnInit } from '@angular/core';
import * as AOS from 'aos';

@Component({
  selector: 'app-alternating-feature',
  templateUrl: './alternating-feature.component.html',
  styleUrls: ['./alternating-feature.component.css']
})
export class AlternatingFeatureComponent implements OnInit {
  ngOnInit(): void {
    AOS.init();
  }
}
