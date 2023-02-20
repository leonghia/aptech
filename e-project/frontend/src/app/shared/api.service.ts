import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private BASE_URL = 'http://localhost:5000/api';

  constructor(private http: HttpClient) { }

  getBridges(): Observable<any> {
    return this.http.get(`${this.BASE_URL}/bridges`);
  }
}
