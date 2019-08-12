import { Food } from './food.model';
import { HttpClient } from '@angular/common/http'; // added
import { Inject, Injectable } from '@angular/core'; // added

@Injectable()
export class Repository {

	public food: Food;
	constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
		http
			.get<Food>(baseUrl + 'api/SampleData/GetFood')
			.subscribe(result => {
				this.food = result;
			},
				error => console.error(error));
	}
}
