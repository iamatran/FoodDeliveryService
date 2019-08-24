import { NgModule } from '@angular/core';
import { Repository } from './repository';
import { Cart } from "./cart.model";
import { Order } from "./order.model";

//This is here to register classes in the decorator for dependency injection

@NgModule({
	providers: [Repository, Cart, Order]
})
export class ModelModule { }
