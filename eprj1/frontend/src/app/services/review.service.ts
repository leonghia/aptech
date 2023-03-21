import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const REVIEW_API = 'http://localhost:8080/api/reviews';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  constructor(private http: HttpClient) { }

  postReview(user_id: number, bridge_id: number, rating: number, content: string, title: string): Observable<any> {
    return this.http.post(REVIEW_API, {
      user_id,
      bridge_id,
      rating,
      content,
      title
    }, httpOptions)

  }

  getReviews(bridge_id: string): Observable<any> {
    let params: {[key: string]: any} = {};
    params = { ...params, bridge_id };
    return this.http.get<any>(REVIEW_API, { params });
  }
}
