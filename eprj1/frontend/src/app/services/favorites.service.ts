import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { FavoritesNotiService } from '../components/favorites/favorites-noti/favorites-noti.service';

const FAVORITE_API = 'http://localhost:8080/api/favorites';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class FavoritesService {
  favorites?: any[];
  favoritesLength?: number;
  favoritesLengthChanged = new BehaviorSubject<number | undefined>(0);
  isNotified = new BehaviorSubject<{ bridgeName: string, status: string }>({ bridgeName: '', status: '' });

  constructor(private http: HttpClient, private favoritesNotiService: FavoritesNotiService) { }

  addFavorite(user_id: number | string, bridge_id: number | string, bridgeName: string): Observable<any> | void {
    this.favoritesNotiService.showFavoritesNoti();
    this.getFavorites(user_id).subscribe((bridges: any[]) => {
      this.favorites = bridges;
      this.favoritesLength = bridges.length;
      // Check if the bridge already existing in the favorites
      const duplicatedBridge = this.favorites.some((bridge: any) => bridge.id === bridge_id);
      // If existing, emit an event isDuplicated and quit
      if (duplicatedBridge) {
        this.isNotified.next({ bridgeName: bridgeName, status: 'duplicated' });
        console.log('bridge already existing in favorites');
        return;
      }

      //Otherwise, increment the favorites length by 1, emit and event isAdded then add the bridge to favorites
      this.favoritesLengthChanged.next(++this.favoritesLength);
      this.isNotified.next({ bridgeName: bridgeName, status: 'added' });
      console.log('bridge added to favorites');
      this.http.post(FAVORITE_API, {
        user_id,
        bridge_id
      }, httpOptions).subscribe(data => {

      })
    })
  }

  getFavorites(user_id: string | number): Observable<any> {
    let params: { [key: string]: any } = {};
    params = { ...params, user_id };
    return this.http.get<any>(FAVORITE_API, { params });
  }
}
