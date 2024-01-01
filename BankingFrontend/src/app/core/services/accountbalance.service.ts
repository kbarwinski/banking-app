import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from './constants/baseurl';

const url = baseUrl + '/balance';
const headers = new HttpHeaders().set('Accept', 'text/plain');

export interface AccountBalanceModel {
  date: Date;
  amount: number;
}

export interface AccountBalanceHistoryModel {
  balanceHistory: AccountBalanceModel[];
}

@Injectable({ providedIn: 'root' })
export default class AccountBalanceService {
  constructor(private readonly http: HttpClient) {}

  public getAccountBalance(): Observable<any> {
    return this.http.get(url, {
      headers: headers,
    });
  }
}
