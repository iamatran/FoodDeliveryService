import { Component } from "@angular/core";
import { Repository } from "../models/repository";

@Component({
    selector: "store-categoryfilter",
    templateUrl: "categoryFilter.component.html"
})

//we're grabbing the categories to feed it into the categfory filter class
export class CategoryFilterComponent {
    constructor(private repo: Repository) { }
    get categories(): string[] {
        return this.repo.categories;
    }
    get currentCategory(): string {
        return this.repo.filter.category;
    }
    setCurrentCategory(newCategory: string) {
        this.repo.filter.category = newCategory;
        this.repo.getFoods();
    }

}
