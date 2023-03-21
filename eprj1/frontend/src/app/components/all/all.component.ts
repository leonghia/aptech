import { Component, ElementRef, OnInit, QueryList, ViewChildren } from '@angular/core';
import { fadeIn } from 'src/app/animations/fade';
import { BridgeService } from 'src/app/services/bridge.service';
import { FavoritesService } from 'src/app/services/favorites.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { CompareService } from '../compare/compare.service';

@Component({
  selector: 'app-all',
  animations: [fadeIn],
  templateUrl: './all.component.html',
  styleUrls: ['./all.component.css']
})
export class AllComponent implements OnInit {
  @ViewChildren('checkboxes') checkboxes!: QueryList<ElementRef>;
  continentBtnState: boolean = false;
  selectedContinent: string = '';
  defaultContinentText: string = 'Please select a continent';
  hoveredContinent!: string;
  countryBtnState: boolean = false;
  selectedCountry: string = '';
  defaultCountryText: string = 'Please select a country'
  hoveredCountry!: string;
  sortBtnState: boolean = false;
  orderBtnState: boolean = false;
  bridges!: any[];
  continents!: any[];
  countries!: any[];
  materials!: any[];
  selectedMaterials: string[] = [];
  styles!: any[];
  selectedStyles: string[] = [];
  enterViewport: boolean = false;
  sortBy: string = 'name';
  orderBy: string = 'asc';
  sortText!: string;
  orderText!: string;
  firstLoad: boolean = true;
  loading: boolean = true;

  user_id!: number;
  isLoggedIn: boolean = false;

  constructor(private bridgeService: BridgeService, private compareService: CompareService, private tokenStorageService: TokenStorageService, private favoritesService: FavoritesService) {}

  ngOnInit(): void {
    this.bridgeService.getMaterials().subscribe(data => {
      this.materials = data;
    });
    this.bridgeService.getStyles().subscribe(data => {
      this.styles = data;
    })
    this.bridgeService.getBridges({sort: this.sortBy, order: this.orderBy}).subscribe(data => {
      this.bridges = data;
      this.loading = false;
      this.firstLoad = false;
    });
    this.bridgeService.getContinents().subscribe(data => {
      this.continents = data;
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

  onToggleContinentBtn(): void {
    this.countryBtnState = false;
    this.continentBtnState = !this.continentBtnState;
  }

  onSelectContinent(continent: string): void {
    this.loading = true;
    this.selectedContinent = continent;
    this.continentBtnState = false;
    this.selectedCountry = '';
    if (continent === '') {
      this.defaultContinentText = 'All continents';
      this.countries = [];
      setTimeout(() => {
        this.bridgeService.getBridges({continent: this.selectedContinent, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), sort: this.sortBy, order: this.orderBy}).subscribe(data => {
          this.bridges = data;
          this.loading = false;
        });
        
      }, 1000);
      
    } else {
      setTimeout(() => {
        this.bridgeService.getBridges({continent: this.selectedContinent, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), sort: this.sortBy, order: this.orderBy}).subscribe(data => {
          this.bridges = data;
          this.loading = false;
        });
        
      }, 1000);
      this.bridgeService.getCountries(this.selectedContinent).subscribe(data => {
        this.countries = data;
      });
    }
  }

  onToggleCountryBtn(): void {
    this.continentBtnState = false;
    this.countryBtnState = !this.countryBtnState;
  }

  onSelectCountry(country: string): void {
    this.loading = true;
    this.selectedCountry = country;
    this.countryBtnState = false;
    if (country === '') {
      this.defaultCountryText = 'All countries';
      setTimeout(() => {
        this.bridgeService.getBridges({continent: this.selectedContinent, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
          this.bridges = data;
          this.loading = false;
        })
      }, 1000);
      
    } else {
      setTimeout(() => {
        this.bridgeService.getBridges({country: this.selectedCountry, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
          this.bridges = data;
          this.loading = false;
        })
      }, 1000);
      
    }
    
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
      this.bridgeService.getBridges({continent: this.selectedContinent, country: this.selectedCountry, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
        this.bridges = data;
        this.loading = false;
      })
    }, 1000);
    
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
      this.bridgeService.getBridges({continent: this.selectedContinent, country: this.selectedCountry, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
        this.bridges = data;
        this.loading = false;
      })
    }, 1000);
    
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
    this.loading = true;
    this.orderBy = order;
    this.orderText = order;
    this.orderBtnState = false;
    this.bridgeService.getBridges({continent: this.selectedContinent, country: this.selectedCountry, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), sort: this.sortBy, order: this.orderBy}).subscribe(data => {
      this.bridges = data;
      this.loading = false;
    })
  }

  onResetFilter(): void {
    this.checkboxes.forEach((element) => {
      element.nativeElement.checked = false;
    });
    this.selectedContinent = '';
    this.selectedCountry = '';
    this.selectedMaterials = [];
    this.selectedStyles = [];
    this.loading = true;
    this.bridgeService.getBridges({sort: this.sortBy, order: this.orderBy}).subscribe(data => {
      this.bridges = data;
      this.loading = false;
    });
  }

  onAddBridgeToCompare(bridge: any) {
    this.compareService.addBridgeToComparison(bridge);
  }

  onAddBridgeToFavorites(bridge_id: string | number, bridgeName: string) {
    this.favoritesService.addFavorite(this.user_id, bridge_id, bridgeName);
  }

}
