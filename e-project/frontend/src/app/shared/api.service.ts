import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private BASE_URL = 'http://localhost:5000/api';

  constructor(private http: HttpClient) { }

  getBridges(criteria: string): Observable<any> {
    return this.http.get(`${this.BASE_URL}/bridges/${criteria}`);
  }

  sortBridges(sort: string, order: string): Observable<any> {
    return this.http.get(`${this.BASE_URL}/bridges?sort=${sort}&order=${order}`);
  }

  getBridge(id: string): Observable<any> {
    return this.http.get(`${this.BASE_URL}/bridge/${id}`);
  }

  getImages(criteria: string): Observable<any> {
    return this.http.get(`${this.BASE_URL}/bridge-images/${criteria}`);
  }
}
