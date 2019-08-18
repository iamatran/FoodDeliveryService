import { Food } from './food.model';
import { HttpClient } from '@angular/common/http'; // added
import { Inject, Injectable } from '@angular/core'; // added
import { Filter } from "./configClasses.repository";

const foodsUrl = "/api/foods";
@Injectable()
export class Repository {
	private filterObject = new Filter();
	constructor(private http: HttpClient) {
		this.filter.category = "Bobs Burgers";
        this.filter.related = true;
		this.getFoods(true);
	}
	getFood(id: number) {
		//console.log("Food Data Requested");
		this.http.get(foodsUrl + "/" + id)
			.subscribe(response => {this.food = response});
	}
	getFoods(related = false) {
		let url = foodsUrl + "?related=" + this.filter.related;
        if (this.filter.category) {
            url += "&category=" + this.filter.category;
        }
        if (this.filter.search) {
            url += "&search=" + this.filter.search;
        }

		this.http.get<Food[]>(url)
		.subscribe(response => this.foods = response);
		}

	food: Food;
	foods: Food[];

	get filter(): Filter {
		return this.filterObject;
	}
}
