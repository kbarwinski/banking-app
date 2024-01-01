import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import TransactionCategoriesService from 'src/app/core/services/transactioncategories.service';
import { TransactionCategoryModel } from 'src/app/core/services/transactions.service';

@Component({
  selector: 'app-category-dropdown',
  templateUrl: './category-dropdown.component.html',
})
export class CategoryDropdownComponent implements OnInit {
  @Input() multipleSelection: boolean = true;
  @Input() category: FormControl = new FormControl('');

  public categories!: TransactionCategoryModel[];

  constructor(private categoryService: TransactionCategoriesService) {}

  ngOnInit() {
    this.categoryService.getTransactionCategories().subscribe((data) => {
      this.categories = data;
    });
  }
}
