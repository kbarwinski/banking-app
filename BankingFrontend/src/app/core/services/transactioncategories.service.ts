import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from './constants/baseurl';

const url = baseUrl + '/transactioncategories';
const headers = new HttpHeaders().set('Accept', 'text/plain');

@Injectable({ providedIn: 'root' })
export default class TransactionCategoriesService {
  constructor(private readonly http: HttpClient) {}

  public getTransactionCategories(): Observable<any> {
    return this.http.get(url, {
      headers: headers,
    });
  }
}
