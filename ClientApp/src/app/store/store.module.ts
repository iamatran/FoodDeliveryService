import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';
import { CartSummaryComponent } from "./cartSummary.component";
import { CategoryFilterComponent } from "./categoryFilter.component";
import { PaginationComponent } from "./pagination.component";
import { FoodListComponent } from "./foodList.component";
import { RatingsComponent } from "./ratings.component";
import { FoodSelectionComponent } from "./foodSelection.component";

@NgModule({
    declarations: [CartSummaryComponent, CategoryFilterComponent,
        PaginationComponent, FoodListComponent, RatingsComponent,
        FoodSelectionComponent],
    imports: [BrowserModule],
    exports: [FoodSelectionComponent]
})
export class StoreModule { }