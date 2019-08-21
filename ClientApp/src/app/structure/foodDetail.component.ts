import { Component } from '@angular/core';
import { Repository } from "../models/repository";
import { Food } from "../models/food.model";

@Component({
    selector: "food-detail",
    templateUrl: "foodDetail.component.html"
})

//This class accepts the repository and has a property to return a food item.
export class FoodDetailComponent {
    constructor(private repo: Repository) { }
    get food(): Food {
        return this.repo.food;
    }
}
