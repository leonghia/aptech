import { Component, OnInit } from '@angular/core';
import { FavoritesService } from 'src/app/services/favorites.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent implements OnInit {
  user_id!: number;
  bridges!: any[];

  isLoggedIn: boolean = false;

  constructor(private tokenStorageService: TokenStorageService, private favoritesService: FavoritesService) {}

  ngOnInit(): void {
    this.isLoggedIn = !!this.tokenStorageService.getToken();
    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();
      this.user_id = user.id;
      this.favoritesService.getFavorites(this.user_id).subscribe((bridges: any[]) => {
        this.bridges = bridges;
      })
    };
  }

}