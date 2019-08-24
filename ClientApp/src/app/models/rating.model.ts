import { Food } from './food.model';

//This is our data model with a constructor that can be used to configure a new instance of the class
export class Rating {
	constructor(
		public ratingId?: number,
		public stars?: number,
		public food?: Food) { }
}
