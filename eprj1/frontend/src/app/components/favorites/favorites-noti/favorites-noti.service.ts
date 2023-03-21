import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FavoritesNotiService {
  favoritesNotiStateChanged = new Subject<boolean>();

  constructor() { }

  showFavoritesNoti() {
    this.favoritesNotiStateChanged.next(true);
  }

  closeFavoritesNoti() {
    this.favoritesNotiStateChanged.next(false);
  }
}
