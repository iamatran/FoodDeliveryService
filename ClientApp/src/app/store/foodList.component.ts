import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Food } from "../models/food.model";
import { Cart } from "../models/cart.model";


@Component({
    selector: "store-food-list",
    templateUrl: "foodList.component.html"
})

//This displays a list of food items to the user using the slice method to determine which food items to display
//also passes in cart for the addToCart method
export class FoodListComponent {
    constructor(private repo: Repository, private cart: Cart) { }
    get foods(): Food[] {
        if (this.repo.foods != null && this.repo.foods.length > 0) {
            let pageIndex = (this.repo.pagination.currentPage - 1)
                * this.repo.pagination.foodsPerPage;
            return this.repo.foods.slice(pageIndex,
                pageIndex + this.repo.pagination.foodsPerPage);
        }
    }
    addToCart(food: Food) {
        this.cart.addFood(food);
    }
}
