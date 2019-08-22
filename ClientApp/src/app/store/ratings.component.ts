import { Component, Input } from "@angular/core";
import { Food } from "../models/food.model";
@Component({
    selector: "store-ratings",
    templateUrl: "ratings.component.html"
})
//This is going to average out the stars and use the angular input to receive data from the template
export class RatingsComponent {
    @Input()
    food: Food;
    //this will generate an array boolean values and return the ratings in boolean
    get stars(): boolean[] {
        if (this.food != null && this.food.ratings != null) {
            let total = this.food.ratings.map(r => r.stars)
                .reduce((prev, curr) => prev + curr, 0);
            let count = Math.round(total / this.food.ratings.length);
            return Array(5).fill(false).map((value, index) => {
                return index < count;
            });
        } else {
            return [];
        }
    }
}
