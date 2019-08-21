import { Component } from '@angular/core';
import { Repository } from "../models/repository";
import { Food } from "../models/food.model";

@Component({
    selector: "food-table",
    templateUrl: "./foodTable.component.html"
})

//This class contains a constructor declares a dependency on the Repository and a method to get the foods
export class FoodTableComponent {
    constructor(private repo: Repository) { }
    get foods(): Food[] {
        return this.repo.foods;
    }
    //this food method calls on the repository and uses the getFood method to send a request to the web service
    selectFood(id: number) {
        this.repo.getFood(id);
    }
}
