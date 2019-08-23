import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Food } from "../models/food.model";
import { Address } from "../models/address.model";

@Component({
    selector: "admin-food-editor",
    templateUrl: "foodEditor.component.html"
})
export class FoodEditorComponent {
    constructor(private repo: Repository) { }
    get food(): Food {
        return this.repo.food;
    }
    get addresses(): Address[] {
        return this.repo.addresses;
    }
    compareAddresses(s1: Address, s2: Address) {
        return s1 && s2 && s1.name == s2.name;
    }
}
