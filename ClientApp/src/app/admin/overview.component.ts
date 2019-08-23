import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Food } from "../models/food.model";
import { Order } from "../models/order.model";

@Component({
    templateUrl: "overview.component.html"
})
export class OverviewComponent {
    constructor(private repo: Repository) { }
    get foods(): Food[] {
        return this.repo.foods;
    }
    get orders(): Order[] {
        return this.repo.orders;
    }
}
