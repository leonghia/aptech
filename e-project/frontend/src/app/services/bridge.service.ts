import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BridgeService {
  private BASE_URL = 'http://localhost:8080/api';

  constructor(private http: HttpClient) { }

  getBridges({ id, continent, country, q, material, style, limit, sort, order }: { id?: string, continent?: string, country?: string, q?: string, material?: string, style?: string, limit?: string, sort?: string, order?: string }): Observable<any> {
    let params: {[key: string]: any} = {};

    if (id) {
      params = { ...params, id };
      return this.http.get<any>(`${this.BASE_URL}/bridges`, { params });
    }

    if (continent) params = { ...params, continent };
    if (country) params = { ...params, country };
    if (q) params = { ...params, q };
    if (material) params = { ...params, material };
    if (style) params = { ...params, style };
    if (sort) params = { ...params, sort };
    if (order) params = { ...params, order };
    if (limit) params = { ...params, limit };

    return this.http.get<any>(`${this.BASE_URL}/bridges`, { params });
    
  }

  getContinents(): Observable<any> {
    return this.http.get<any>(`${this.BASE_URL}/continents`);
  }

  getCountries(continent: string): Observable<any> {
    let params: {[key: string]: any} = {};
    params = { ...params, continent };
    return this.http.get<any>(`${this.BASE_URL}/countries`, { params });
  }

  getMaterials(): Observable<any> {
    return this.http.get<any>(`${this.BASE_URL}/materials`);
  }

  getStyles(): Observable<any> {
    return this.http.get<any>(`${this.BASE_URL}/styles`);
  }

  getImages(bridge_id: string): Observable<any> {
    let params: {[key: string]: any} = {};
    params = { ...params, bridge_id };
    return this.http.get<any>(`${this.BASE_URL}/images`, { params });
  }

  addUser(newUser: any): Observable<any> {
    return this.http.post(this.BASE_URL, newUser);
  }

  
}
