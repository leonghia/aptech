import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from 'src/app/services/data.service';

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

  constructor(private dataService: DataService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.loading = true;
    this.dataService.getMaterials().subscribe(data => {
      this.materials = data;
    });
    this.dataService.getStyles().subscribe(data => {
      this.styles = data;
    });
    this.searchTerm = this.route.snapshot.queryParamMap.get('q');
    setTimeout(() => {
      this.dataService.getBridges({q: this.searchTerm, sort: this.sortBy, order: this.orderBy}).subscribe(data => {
        this.bridges = data;
        this.loading = false;
        this.searchResultLength = this.bridges.length;
      });
    }, 1000);
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
      this.dataService.getBridges({q: this.searchTerm, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
        this.bridges = data;
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
      this.dataService.getBridges({q: this.searchTerm, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), order: this.orderBy, sort: this.sortBy}).subscribe(data => {
        this.bridges = data;
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
    this.dataService.getBridges({q: this.searchTerm, material: this.selectedMaterials.join(','), style: this.selectedStyles.join(','), sort: this.sortBy, order: this.orderBy}).subscribe(data => {
      this.bridges = data;
    })
  }
}
