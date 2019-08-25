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
import { CheckoutDetailsComponent } from "./checkout/checkoutDetails.component";
import { CheckoutPaymentComponent } from "./checkout/checkoutPayment.component";
import { CheckoutSummaryComponent } from "./checkout/checkoutSummary.component";
import { OrderConfirmationComponent } from "./checkout/orderConfirmation.component";

//This file configures the angular app and imports all of our modules

@NgModule({
    declarations: [CartSummaryComponent, CategoryFilterComponent,
        PaginationComponent, FoodListComponent, RatingsComponent,
        FoodSelectionComponent,CartDetailComponent,
        CheckoutDetailsComponent, CheckoutPaymentComponent,
        CheckoutSummaryComponent, OrderConfirmationComponent],
    imports: [BrowserModule,RouterModule,FormsModule],
    exports: [FoodSelectionComponent]
})
export class StoreModule { }