import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { BridgeService } from 'src/app/services/bridge.service';
import { FavoritesService } from 'src/app/services/favorites.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { CompareService } from '../compare/compare.service';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css']
})
export class SearchResultComponent implements OnInit {
  searchTerm: any;
  searchResultLength!: number;
  sortBtnState: boolean = false;
  orderBtnState: boolean = false;
  bridges!: any[];
  materials!: any[];
  selectedMaterials: string[] = [];
  styles!: any[];
  selectedStyles: string[] = [];
  enterViewport: boolean = false;
  sortBy: string = 'name';
  orderBy: string = 'asc';
  sortText!: string;
  orderText!: string;
  loading: boolean = true;

  user_id!: number;
  isLoggedIn: boolean = false;

  constructor(private bridgeService: BridgeService, private route: ActivatedRoute, private compareService: CompareService, private tokenStorageService: TokenStorageService, private favoritesService: FavoritesService) {}

  ngOnInit(): void {
    this.loading = true;
    this.bridgeService.getMaterials().subscribe(data => {
      this.materials = data;
    });
    this.bridgeService.getStyles().subscribe(data => {
      this.styles = data;
    });
    this.searchTerm = this.route.snapshot.queryParamMap.get('q');
    this.route.queryParamMap.subscribe(params => {
      this.bridges = [];
      this.loading = true;
      this.searchTerm = params.get('q');
      setTimeout(() => {
        this.bridgeService.getBridges({q: this.searchTerm, sort: this.sortBy, order: this.orderBy}).subscribe(data => {
          this.bridges = data;
          this.loading = false;
          this.searchResultLength = this.bridges.length;
        });
      }, 1000);
    });

    this.isLoggedIn = !!this.tokenStorageService.getToken();
    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();
      this.user_id = user.id;
    };
  }

  onVisibilityChange(status: boolean): void {
    if (status)
      this.enterViewport = status;
  }

  onSelectMaterial(material: string): void {
    this.loading = true;
    const index = this.selectedMaterials.indexOf(material);
    if (index === -1) {
      this.selectedMaterials.push(material);
    } else {
      this.selectedMaterials.splice(index, 1);
    }
    setTimeout(() => {
      this.bridgeService.getBridges({q: this.searchTerm, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
        this.bridges = data;
        this.searchResultLength = this.bridges.length;
        this.loading = false;
      })
    }, 100);
    
  }

  onSelectStyle(style: string): void {
    this.loading = true;
    const index = this.selectedStyles.indexOf(style);
    if (index === -1) {
      this.selectedStyles.push(style);
    } else {
      this.selectedStyles.splice(index, 1);
    }
    setTimeout(() => {
      this.bridgeService.getBridges({q: this.searchTerm, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
        this.bridges = data;
        this.searchResultLength = this.bridges.length;
        this.loading = false;
      })
    }, 100);
    
  }

  onToggleSortBtn(): void {
    this.orderBtnState = false;
    this.sortBtnState = !this.sortBtnState;
  }

  onToggleOrderBtn():void {
    this.sortBtnState = false;
    this.orderBtnState = !this.orderBtnState;
  }

  onSortAndOrder(order: string): void {
    this.orderBy = order;
    this.orderText = order;
    this.orderBtnState = false;
    this.bridgeService.getBridges({q: this.searchTerm, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), sort: this.sortBy, order: this.orderBy}).subscribe(data => {
      this.bridges = data;
    })
  }

  onAddBridgeToCompare(bridge: any) {
    this.compareService.addBridgeToComparison(bridge);
  }

  onAddBridgeToFavorites(bridge_id: number | string, bridgeName: string) {
    this.favoritesService.addFavorite(this.user_id, bridge_id, bridgeName)!.subscribe(data => {

    }, err => {
      
    })
  }
}
