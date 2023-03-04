import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { BridgeService } from 'src/app/services/bridge.service';

@Component({
  selector: 'app-related',
  templateUrl: './related.component.html',
  styleUrls: ['./related.component.css']
})
export class RelatedComponent implements OnInit {
  currentBridgeId!: string;
  relatedBridges!: any[];
  currentContinent!: string;

  constructor(private bridgeService: BridgeService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.currentBridgeId = params['id'];
      this.getContinent(this.currentBridgeId);
    })
  }

  getContinent(bridgeId: string): void {
    this.bridgeService.getBridges({id: bridgeId}).subscribe((data: any) => {
      this.currentContinent = data['continent'];
      this.getRelatedBridges(this.currentContinent);
    })
  }

  getRelatedBridges(continentName: string): void {
    this.bridgeService.getBridges({continent: continentName, limit: '8'}).subscribe((data: any[]) => {
      this.relatedBridges = data;
      this.relatedBridges = this.relatedBridges.filter(bridge => bridge.id !== +this.currentBridgeId);
    })
  }
}
