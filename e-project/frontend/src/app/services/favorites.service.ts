import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const FAVORITE_API = 'http://localhost:8080/api/favorites';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class FavoritesService {

  constructor(private http: HttpClient) { }

  addFavorite(user_id: number | string, bridge_id: number | string): Observable<any> {
    return this.http.post(FAVORITE_API, {
      user_id,
      bridge_id,
    }, httpOptions)

  }

  getFavorites(user_id: string | number): Observable<any> {
    let params: {[key: string]: any} = {};
    params = { ...params, user_id };
    return this.http.get<any>(FAVORITE_API, { params });
  }
}
