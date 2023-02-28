import { Component, ElementRef, OnInit, QueryList, ViewChildren } from '@angular/core';
import { fadeIn } from 'src/app/shared/animations';
import { ApiService } from 'src/app/shared/api.service';

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

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.apiService.getMaterials().subscribe(data => {
      this.materials = data;
    });
    this.apiService.getStyles().subscribe(data => {
      this.styles = data;
    })
    this.apiService.getBridges({sort: this.sortBy, order: this.orderBy}).subscribe(data => {
      this.bridges = data;
      this.loading = false;
      this.firstLoad = false;
    });
    this.apiService.getContinents().subscribe(data => {
      this.continents = data;
    });
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
        this.apiService.getBridges({continent: this.selectedContinent, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), sort: this.sortBy, order: this.orderBy}).subscribe(data => {
          this.bridges = data;
          this.loading = false;
        });
        
      }, 1000);
      
    } else {
      setTimeout(() => {
        this.apiService.getBridges({continent: this.selectedContinent, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), sort: this.sortBy, order: this.orderBy}).subscribe(data => {
          this.bridges = data;
          this.loading = false;
        });
        
      }, 1000);
      this.apiService.getCountries(this.selectedContinent).subscribe(data => {
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
        this.apiService.getBridges({continent: this.selectedContinent, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
          this.bridges = data;
          this.loading = false;
        })
      }, 1000);
      
    } else {
      setTimeout(() => {
        this.apiService.getBridges({country: this.selectedCountry, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
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
      this.apiService.getBridges({continent: this.selectedContinent, country: this.selectedCountry, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
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
      this.apiService.getBridges({continent: this.selectedContinent, country: this.selectedCountry, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
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
    this.orderBy = order;
    this.orderText = order;
    this.orderBtnState = false;
    this.apiService.getBridges({continent: this.selectedContinent, country: this.selectedCountry, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), sort: this.sortBy, order: this.orderBy}).subscribe(data => {
      this.bridges = data;
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
    this.apiService.getBridges({sort: this.sortBy, order: this.orderBy}).subscribe(data => {
      this.bridges = data;
      this.loading = false;
    });
  }

}
