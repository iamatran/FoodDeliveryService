import { Component } from "@angular/core";
import { Cart } from "../models/cart.model";

@Component({
    selector: "store-cartsummary",
    templateUrl: "cartSummary.component.html"
})

//this counts the number of items in cart and gives total price
export class CartSummaryComponent {
    constructor(private cart: Cart) { }
    get itemCount(): number {
        return this.cart.itemCount;
    }
    get totalPrice(): number {
        return this.cart.totalPrice;
    } 
}
