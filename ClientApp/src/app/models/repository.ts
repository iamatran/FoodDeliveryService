import { Food } from "./food.model";
import { HttpClient } from '@angular/common/http'; 
import { Inject, Injectable } from '@angular/core'; 
import { Filter, Pagination } from "./configClasses.repository";
import { Address } from "./address.model";
import { Order } from "./order.model";

//We are creating the base api address variables that will be constructed by our methods
const addressesUrl = "/api/addresses";
const foodsUrl = "/api/foods";
const ordersUrl = "/api/orders";

@Injectable()
export class Repository {
	private filterObject = new Filter();
	private paginationObject = new Pagination();
	
	//Methods for filtering
	constructor(private http: HttpClient) {
        this.filter.related = true;
		this.getFoods();
	}
	getFood(id: number) {
		this.http.get(foodsUrl + "/" + id)
				 .subscribe(response => { this.food = response });
	}
	//Our method to get related data
	getFoods(related = false) {
		let url = foodsUrl + "?related=" + this.filter.related;
        if (this.filter.category) {
            url += "&category=" + this.filter.category;
        }
        if (this.filter.search) {
            url += "&search=" + this.filter.search;
        }

		//here we're grabbing the categories for the filters and setting the pagination to 1
		url += "&metadata=true";
		this.http.get<any>(url)
			.subscribe(response => {
                this.foods = response.data;
				this.categories = response.categories;
				this.pagination.currentPage = 1;
            });
		}
		//gives us a collection of studios
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
		replaceFood(mov: Food) {
			let data = {
				image:mov.image, name: mov.name, category: mov.category,
				description: mov.description, price: mov.price,
				address: mov.address ? mov.address.addressId : 0
			};
			this.http.put(foodsUrl + "/" + mov.foodId, data)
				.subscribe(response => this.getFoods());
		}
		replaceAddress(stu: Address) {
			let data = {
				name: stu.name, city: stu.city, state: stu.state
			};
			this.http.put(addressesUrl + "/" + stu.addressId, data)
				.subscribe(response => this.getFoods());
		}
		//Receives an id and a map object and replaces map  object with new values. We also use the subscribe method to reload data from the web service
		updateFood(id: number, changes: Map<string, any>) {
			let patch = [];
			changes.forEach((value, key) =>
			patch.push({ op: "replace", path: key, value: value }));
			this.http.patch(foodsUrl + "/" + id, patch)
			.subscribe(response => this.getFoods());
		}
		//these are our delete methods
		deleteFood(id: number) {
			this.http.delete(foodsUrl + "/" + id)
				.subscribe(response => this.getFoods());
		}
		deleteAddress(id: number) {
			this.http.delete(addressesUrl + "/" + id)
				.subscribe(response => {
					this.getFoods();
					this.getAddresses();
				});
		}
		//These are methods to store and get session data
		storeSessionData(dataType: string, data: any) {
			return this.http.post("/api/session/" + dataType, data)
				.subscribe(response => { });
		}
		getSessionData(dataType: string): any {
			return this.http.get("/api/session/" + dataType);
		}
		//Methods related to getting and creating orders and a way to clear the order
		getOrders() {
			this.http.get<Order[]>(ordersUrl)
				.subscribe(data => this.orders = data);
		}
		createOrder(order: Order) {
			this.http.post<any>(ordersUrl, {
				name: order.name,
				address: order.address,
				payment: order.payment,
				foods: order.foods
			}).subscribe(data => {
				order.orderConfirmation = data
				order.cart.clear();
				order.clear();
			});
		}
		shipOrder(order: Order) {
			this.http.post(ordersUrl + "/" + order.orderId,null)
				.subscribe(r => this.getOrders())
		}
	
	food: Food;
	foods: Food[];
	addresses: Address[] = [];
	categories: string[] = [];
	orders: Order[] = [];


	get filter(): Filter {
		return this.filterObject;
	}
	get pagination(): Pagination {
		return this.paginationObject;
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
