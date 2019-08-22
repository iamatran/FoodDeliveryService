import { Injectable } from "@angular/core";
import { Food } from "./food.model";

@Injectable()
//This is the users shopping cart
export class Cart {
    selections: FoodSelection[] = [];
    itemCount: number = 0;
    totalPrice: number = 0;
    //method to add food to the cart
    addFood(food: Food) {
        let selection = this.selections
            .find(ps => ps.foodId == food.foodId);
        if (selection) {
            selection.quantity++;
        } else {
            this.selections.push(new FoodSelection(this,
                food.foodId, food.name,
                food.price, 1));
        }
        this.update();
    }
    //Lets the user adjust the items in cart
    updateQuantity(foodId: number, quantity: number) {
        if (quantity > 0) {
            let selection = this.selections.find(ps => ps.foodId == foodId);
            if (selection) {
                selection.quantity = quantity;
            }
        } else {
            let index = this.selections.findIndex(ps => ps.foodId == foodId);
            if (index != -1) {
                this.selections.splice(index, 1);
            }
            this.update();
        }
    }
    //this clears out the shopping cart 
    clear() {
        this.selections = [];
        this.update();
    }
    //keeps track of item count and total price
    update() {
        this.itemCount = this.selections.map(ps => ps.quantity)
            .reduce((prev, curr) => prev + curr, 0);
        this.totalPrice = this.selections.map(ps => ps.price * ps.quantity)
            .reduce((prev, curr) => prev + curr, 0);
    }
}
//This allows for individual food item choices
export class FoodSelection {
    constructor(public cart: Cart,
        public foodId?: number,
        public name?: string,
        public price?: number,
        private quantityValue?: number) { }
    get quantity() {
        return this.quantityValue;
    }
    set quantity(newQuantity: number) {
        this.quantityValue = newQuantity;
        this.cart.update();
    }
}
