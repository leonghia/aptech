import { Injectable } from '@angular/core';
import { FavoritesService } from 'src/app/services/favorites.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class FavoritesNotiService  {
  isLoggedIn: boolean = false;
  user_id!: number;
  favoritesBridgesLength!: number;


  constructor(private tokenStorageService: TokenStorageService, private favoritesService: FavoritesService) { }


}
