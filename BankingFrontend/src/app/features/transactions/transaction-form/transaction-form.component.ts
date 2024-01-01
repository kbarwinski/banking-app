import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

import TransactionsService, {
  TransactionCategoryModel,
} from 'src/app/core/services/transactions.service';
import { CreateTransactionCommand } from 'src/app/core/services/transactions.service';

@Component({
  selector: 'app-transaction-form',
  templateUrl: './transaction-form.component.html',
  styleUrls: ['./transaction-form.component.scss'],
})
export class TransactionFormComponent {
  constructor(
    private transactionsService: TransactionsService,
    private router: Router
  ) {}

  navigateToListRoute() {
    this.router.navigate(['']);
  }

  public selectedCategory!: TransactionCategoryModel;

  transactionForm = new FormGroup({
    name: new FormControl(''),
    description: new FormControl(''),
    amount: new FormControl(0),
    category: new FormControl(''),
    occuredAt: new FormControl(new Date()),
  });

  onSubmit() {
    if (this.transactionForm.valid) {
      this.transactionsService
        .createTransaction(
          this.transactionForm.value as CreateTransactionCommand
        )
        .subscribe((response: any) => {
          this.navigateToListRoute();
        });
    }
  }
}
