import { Food } from './food.model';
import { HttpClient } from '@angular/common/http'; // added
import { Inject, Injectable } from '@angular/core'; // added

const foodsUrl = "/api/foods";
@Injectable()
export class Repository {

	public food: Food;
	constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
		http.get<Food>(baseUrl + 'api/foods/GetFood')
		.subscribe(result => {
		this.food = result;
		},
			error => console.error(error));

			this.getFood(3);
	}
	getFood(id: number) {
		//console.log("Food Data Requested");
		this.http.get(foodsUrl + "/" + id)
			.subscribe(response => {this.food = response});

	}

}
