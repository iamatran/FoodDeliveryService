import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';
import { CartSummaryComponent } from "./cartSummary.component";
import { CategoryFilterComponent } from "./categoryFilter.component";
import { PaginationComponent } from "./pagination.component";
import { FoodListComponent } from "./foodList.component";
import { RatingsComponent } from "./ratings.component";
import { FoodSelectionComponent } from "./foodSelection.component";
import { CartDetailComponent } from "./cartDetail.component";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";

@NgModule({
    declarations: [CartSummaryComponent, CategoryFilterComponent,
        PaginationComponent, FoodListComponent, RatingsComponent,
        FoodSelectionComponent,CartDetailComponent],
    imports: [BrowserModule,RouterModule,FormsModule],
    exports: [FoodSelectionComponent]
})
export class StoreModule { }