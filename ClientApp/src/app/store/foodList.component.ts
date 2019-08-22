import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Food } from "../models/food.model";

@Component({
    selector: "store-food-list",
    templateUrl: "foodList.component.html"
})

//This displays a list of food items to the user using the slice method to determine which food items to display
export class FoodListComponent {
    constructor(private repo: Repository) { }
    get foods(): Food[] {
        if (this.repo.foods != null && this.repo.foods.length > 0) {
            let pageIndex = (this.repo.pagination.currentPage - 1)
                * this.repo.pagination.foodsPerPage;
            return this.repo.foods.slice(pageIndex,
                pageIndex + this.repo.pagination.foodsPerPage);
    }
}
