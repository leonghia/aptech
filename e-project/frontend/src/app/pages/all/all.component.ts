import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { fadeIn } from 'src/app/shared/animations';
import { ApiService } from 'src/app/shared/api.service';

@Component({
  selector: 'app-all',
  animations: [fadeIn],
  templateUrl: './all.component.html',
  styleUrls: ['./all.component.css']
})
export class AllComponent implements OnInit {
  sortBtnState: boolean = false;
  countryBtnState: boolean = false;
  bridges!: any[];
  enterViewport: boolean = false;
  sortName: string = 'country';

  constructor(private apiService: ApiService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.apiService.getBridges('all').subscribe(
      (data: any[]) => this.bridges = data
    );
  }

  onVisibilityChange(status: boolean): void {
    if (status)
      this.enterViewport = status;
  }

  onToggleSortBtn(): void {
    this.sortBtnState = !this.sortBtnState;
  }

  onSortBridges(sort: string, order: string): void {
    this.apiService.sortBridges(sort, order).subscribe(data => {
      this.bridges = data;
      this.sortName = sort;
    });
    this.sortBtnState = false;
  }

  onToggleCountryBtn(): void {
    this.countryBtnState = !this.countryBtnState;
  }

}
