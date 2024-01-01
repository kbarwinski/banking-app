import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from './constants/baseurl';

const url = baseUrl + '/transactions';
const headers = new HttpHeaders().set('Accept', 'text/plain');

export interface TransactionCategoryModel {
  id: string;
  name: string;
  isIncomeCateory: boolean;
}

export interface TransactionBaseModel {
  name: string;
  description: string;
  amount: number;
  category: TransactionCategoryModel;
  occuredAt: Date;
}

export interface TransactionViewModel extends TransactionBaseModel {
  id: string;
  createdAt: Date;
}

export interface PaginationModel {
  page: number;
  pageSize: number;
  sortingOrders: string;
  totalCount: number;
  hasNext: boolean;
  hasPrev: boolean;
}

export interface GetTransactionsQuery extends PaginationModel {
  categoryIds: string[];
  sortingOrders: string;
}

export interface GetTransactionQuery {
  id: string;
}

export interface CreateTransactionCommand {
  model: TransactionBaseModel;
}

@Injectable({ providedIn: 'root' })
export default class TransactionsService {
  constructor(private readonly http: HttpClient) {}

  public getTransactions(request: GetTransactionsQuery): Observable<any> {
    let params = new HttpParams()
      .set('page', request.page)
      .set('pageSize', request.pageSize)
      .set('sortingOrders', request.sortingOrders);

    if (request.categoryIds)
      request.categoryIds.forEach(
        (id) => (params = params.append('CategoryIds', id))
      );

    return this.http.get(url, {
      headers: headers,
      params: params,
    });
  }

  public createTransaction(request: CreateTransactionCommand): Observable<any> {
    return this.http.post(url, request);
  }

  get(id: string): Observable<any> {
    return this.http.get(url + '/' + id, { headers });
  }

  delete(id: string): Observable<any> {
    return this.http.delete(url + '/' + id, { headers });
  }
}
