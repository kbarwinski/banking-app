import { Component, OnInit } from '@angular/core';
import { ChartData } from 'chart.js';
import AccountBalanceService, {
  AccountBalanceHistoryModel,
} from 'src/app/core/services/accountbalance.service';

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.scss'],
})
export class BalanceComponent implements OnInit {
  constructor(private accountBalanceService: AccountBalanceService) {}

  public isLoading: boolean = true;

  public balanceHistory!: ChartData;

  ngOnInit(): void {
    this.fetchAccountBalance();
  }

  private formatDate(date: Date): string {
    let day = ('0' + date.getDate()).slice(-2);
    let month = ('0' + (date.getMonth() + 1)).slice(-2);
    let year = date.getFullYear();
    return `${day}.${month}.${year}`;
  }

  private initializeBalanceData(response: AccountBalanceHistoryModel) {
    this.balanceHistory = {
      labels: response.balanceHistory.map((x) =>
        this.formatDate(new Date(x.date))
      ),
      datasets: [
        {
          label: 'Balance',
          data: response.balanceHistory.map((x) => x.amount),
        },
      ],
    };
  }

  public async fetchAccountBalance() {
    this.isLoading = true;

    (await this.accountBalanceService.getAccountBalance()).subscribe(
      (response: any) => {
        this.initializeBalanceData(response);
        this.isLoading = false;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }
}
