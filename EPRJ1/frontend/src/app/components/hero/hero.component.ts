import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-hero',
  templateUrl: './hero.component.html',
  styleUrls: ['./hero.component.css']
})
export class HeroComponent {
  searchTerm!: string;

  constructor(private router: Router) {}

  onSubmit(searchTerm: string): void {
    this.router.navigate(['/search'], { queryParams: { q: searchTerm } });
  }
}
