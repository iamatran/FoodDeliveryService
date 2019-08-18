import { Food } from "./food.model";
import { HttpClient } from '@angular/common/http'; 
import { Inject, Injectable } from '@angular/core'; 
import { Filter } from "./configClasses.repository";
import { Address } from "./address.model";

const addressesUrl = "/api/addresses";
const foodsUrl = "/api/foods";
@Injectable()
export class Repository {
	private filterObject = new Filter();
	constructor(private http: HttpClient) {
		//this.filter.category = "drama";
        this.filter.related = true;
		this.getFoods();
	}
	getFood(id: number) {
		//console.log("Food Data Requested");
		this.http.get(foodsUrl + "/" + id)
				 .subscribe(response => { this.food = response });
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

		getAddresses() {
			this.http.get<Address[]>(addressesUrl)
				.subscribe(response => this.addresses = response);
		}
		createFood(mov: Food) {
			let data = {
				Image:mov.image, name: mov.name, category: mov.category,
				description: mov.description, price: mov.price,
				address: mov.address ? mov.address.addressId : 0
			};
			this.http.post<number>(foodsUrl, data)
				.subscribe(response => {
					mov.foodId = response;
					this.foods.push(mov);
				});
		}
		createFoodAndAddress(mov: Food, stu: Address) {
			let data = {
				name: stu.name, city: stu.city, state: stu.state
			};
			this.http.post<number>(addressesUrl, data)
				.subscribe(response => {
					stu.addressId = response;
					mov.address = stu;
					this.addresses.push(stu);
					if (mov != null) {
						this.createFood(mov);
					}
				});
		}
	
	
	food: Food;
	foods: Food[];
	addresses: Address[] = [];
	get filter(): Filter {
		return this.filterObject;
	}
}










































// import { Food } from './food.model';
// import { HttpClient } from '@angular/common/http'; // added
// import { Inject, Injectable } from '@angular/core'; // added
// import { Filter } from "./configClasses.repository";
// import { Address } from "./address.model";

// const foodsUrl = "/api/foods";
// @Injectable()
// export class Repository {
// 	private filterObject = new Filter();
// 	constructor(private http: HttpClient) {
// 		this.filter.category = "Bobs Burgers";
//         this.filter.related = true;
// 		this.getFoods();
// 	}
// 	getFood(id: number) {
// 		//console.log("Food Data Requested");
// 		this.http.get(foodsUrl + "/" + id)
// 			.subscribe(response => {this.food = response});
// 	}
// 	getFoods(related = false) {
// 		let url = foodsUrl + "?related=" + this.filter.related;
//         if (this.filter.category) {
//             url += "&category=" + this.filter.category;
//         }
//         if (this.filter.search) {
//             url += "&search=" + this.filter.search;
//         }

// 		this.http.get<Food[]>(url)
// 		.subscribe(response => this.foods = response);
// 		}

// 	food: Food;
// 	foods: Food[];

// 	get filter(): Filter {
// 		return this.filterObject;
// 	}
// }
