import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Params, Router } from '@angular/router';
import { fadeLeft, fadeRight } from 'src/app/animations/fade';
import { BridgeService } from 'src/app/services/bridge.service';

@Component({
  selector: 'app-categorized',
  animations: [fadeLeft, fadeRight],
  templateUrl: './categorized.component.html',
  styleUrls: ['./categorized.component.css']
})
export class CategorizedComponent implements OnInit {
  header!: string;
  country!: string;
  sort!: string;
  order!: string;
  bridges!: any[];
  enterViewport: boolean[] = [];

  constructor(private bridgeService: BridgeService, private route: ActivatedRoute) {
    
  }

  ngOnInit(): void {
    this.header = this.route.snapshot.params['sort'];
    this.route.params.subscribe((params: Params) => {
      switch(params['sort']) {
        case 'longest':
          this.country = '';
          this.sort = 'length';
          this.order = 'desc';
          break;
        case 'widest':
          this.country = '';
          this.sort = 'width';
          this.order = 'desc';
          break;
        case 'highest':
          this.country = '';
          this.sort = 'height';
          this.order = 'desc';
          break;
        case 'oldest':
          this.country = '';
          this.sort = 'built_in';
          this.order = 'asc';
          break;
        case 'united-states':
          this.country = 'United States';
          this.sort = 'name';
          this.order = 'asc';
          break;
        case 'england':
          this.country = 'England';
          this.sort = 'name';
          this.order = 'asc';
          break;
        case 'chinese':
          this.country = 'China';
          this.sort = 'name';
          this.order = 'asc';
          break;
        case 'japanese':
          this.country = 'Japan';
          this.sort = 'name';
          this.order = 'asc';
          break;
      }
      if (params['sort'] === 'united-states') {
        this.header = 'united states';
      } else {
        this.header = params['sort'];
      }
      this.onRouteChange(this.country, this.sort, this.order);
    })
  }

  onRouteChange(countryBy: string, sortBy: string, orderBy: string) {
    if (this.country === '') {
      this.bridgeService.getBridges({sort: sortBy, order: orderBy, limit: '5'}).subscribe(data => {
        this.bridges = data;
      });
    } else {
      this.bridgeService.getBridges({country: countryBy, sort: sortBy, order: orderBy}).subscribe(data => {
        this.bridges = data;
      });
    } 
    
    this.enterViewport = [];
  } 

  onVisibilityChange(status: boolean, i: number): void {
    if (status) {
      this.enterViewport[i] = true;
    }
  }
}
