import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Food } from "../models/food.model";

@Component({
    selector: "store-food-list",
    templateUrl: "foodList.component.html"
})

//This displays a list of food items to the user
export class FoodListComponent {
    constructor(private repo: Repository) { }
    get foods(): Food[] {
        return this.repo.foods;
    }
}
