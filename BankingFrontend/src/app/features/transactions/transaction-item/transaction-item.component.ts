import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { TransactionViewModel } from 'src/app/core/services/transactions.service';

@Component({
  selector: 'app-transaction-item',
  templateUrl: './transaction-item.component.html',
  styleUrls: ['./transaction-item.component.scss'],
})
export class TransactionItemComponent {
  @Input() transaction!: TransactionViewModel;
  @Output() transactionDeleted = new EventEmitter<string>();

  markForDeletion(id: string) {
    this.transactionDeleted.emit(id);
  }
}
