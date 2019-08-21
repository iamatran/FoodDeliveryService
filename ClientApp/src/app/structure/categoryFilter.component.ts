import { Component } from '@angular/core';
import { Repository } from "../models/repository";

@Component({
    selector: "category-filter",
    templateUrl: "categoryFilter.component.html"
})

//This component class has a constructor to receive a repository object and sets the category method
export class CategoryFilterComponent {
    public romanceCategory = "romance";
    constructor(private repo: Repository) { }
    setCategory(category: string) {
        this.repo.filter.category = category;
        this.repo.getFoods();
    }
}


