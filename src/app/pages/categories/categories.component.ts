import { Component } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent {
  categories: any = [];

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    this.getCategories();
  }

  getCategories() {
    const url = 'https://dummyjson.com/products/categories';
    this.http.get<any>(url).subscribe(data => {
      this.categories = data;
    })
  }
}
