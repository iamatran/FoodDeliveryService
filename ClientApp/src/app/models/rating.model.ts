import { Food } from './food.model';

export class Rating {
	constructor(
		public ratingId?: number,
		public stars?: number,
		public food?: Food) { }
}
