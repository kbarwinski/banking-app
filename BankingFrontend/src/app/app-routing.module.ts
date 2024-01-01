import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TransactionsComponent } from './features/transactions/transactions.component';
import { BalanceComponent } from './features/balance/balance.component';
import { TransactionFormComponent } from './features/transactions/transaction-form/transaction-form.component';

const routes: Routes = [
  { path: '', component: TransactionsComponent },
  { path: 'balance', component: BalanceComponent },
  { path: 'addtransaction', component: TransactionFormComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
