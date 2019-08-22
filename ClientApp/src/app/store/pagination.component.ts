import { Component } from "@angular/core";
import { Repository } from "../models/repository";

@Component({
    selector: "store-pagination",
    templateUrl: "pagination.component.html"
})
export class PaginationComponent {
    constructor(private repo: Repository) { }

    //this gets and sets the pagination.currentpage property
    get current(): number {
        return this.repo.pagination.currentPage;
    }
    //this makes an array of page sequence numbers for the ngFor buttons
    get pages(): number[] {
        if (this.repo.foods != null) {
            return Array(Math.ceil(this.repo.foods.length
                / this.repo.pagination.foodsPerPage))
                .fill(0).map((x, i) => i + 1);
        } else {
            return [];
        }
    }
    changePage(newPage: number) {
        this.repo.pagination.currentPage = newPage;
    }
}
