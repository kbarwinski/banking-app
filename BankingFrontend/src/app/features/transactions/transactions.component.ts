import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';

import TransactionsService, {
  TransactionCategoryModel,
} from 'src/app/core/services/transactions.service';

import {
  GetTransactionsQuery,
  TransactionViewModel,
} from 'src/app/core/services/transactions.service';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.scss'],
})
export class TransactionsComponent implements OnInit {
  constructor(
    private transactionsService: TransactionsService,
    private router: Router
  ) {}

  navigateToFormRoute() {
    this.router.navigate(['/addtransaction']);
  }

  public transactions: TransactionViewModel[] = [];
  public checkboxValues: any = {};
  public isLoading: boolean = true;

  public pagingOptions: number[] = [3, 5, 10, 25, 100];

  public pickedCategories: FormControl = new FormControl([]);

  public paginationArgs: GetTransactionsQuery = this.getFromLocalStorage(
    'paginationArgs'
  ) || {
    page: 0,
    pageSize: 10,
    totalCount: 0,
    sortingOrders: '',
    categoryIds: [],
  };

  async ngOnInit(): Promise<void> {
    await this.fetchTransactions();
  }

  saveToSessionStorage(key: string, value: any) {
    window.sessionStorage.setItem(key, JSON.stringify(value));
  }

  getFromLocalStorage(key: string): any {
    const data = window.sessionStorage.getItem(key);
    return data ? JSON.parse(data) : null;
  }

  public async fetchTransactions() {
    if (this.pickedCategories.value)
      this.paginationArgs.categoryIds = this.pickedCategories.value.map(
        (x: TransactionCategoryModel) => x.id
      );
      
    this.isLoading = true;
    (
      await this.transactionsService.getTransactions(this.paginationArgs)
    ).subscribe(
      (response: any) => {
        this.transactions = response.result;
        this.paginationArgs.totalCount = response.pagination.totalCount;

        if (
          this.paginationArgs.totalCount > 0 &&
          response.pagination.count == 0
        ) {
          this.paginationArgs.page = 0;
          this.fetchTransactions();
        }

        this.isLoading = false;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  public async deleteTransaction(transactionId: string) {
    this.transactionsService
      .delete(transactionId)
      .subscribe((response: any) => {
        this.fetchTransactions();
      });
  }

  handlePageEvent(event: PageEvent) {
    this.paginationArgs.page = event.pageIndex;
    this.paginationArgs.pageSize = event.pageSize;

    this.saveToSessionStorage('paginationArgs', this.paginationArgs);
    this.fetchTransactions();
  }
}
