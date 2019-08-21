import { Component } from '@angular/core';
import { Repository } from "../models/repository";
import { Food } from "../models/food.model";
import { ActivatedRoute, Router } from '@angular/router';


@Component({
    selector: "food-detail",
    templateUrl: "foodDetail.component.html"
})

//This class accepts the repository and has a property to return a food item.
export class FoodDetailComponent {
    constructor(private repo: Repository,
        router: Router,
        activeRoute: ActivatedRoute
    )  { 
        //Here we can change how the user navigates from the table to the detailed view for a food item
        let id = Number.parseInt(activeRoute.snapshot.params["id"]);
        if (id) {
            this.repo.getFood(id);
        } else {
            router.navigateByUrl("/");
        }
    }
    get food(): Food {
        return this.repo.food;
    }
}
