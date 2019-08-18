import { Address } from './address.model';
import { Rating } from './rating.model';

export class Food {
	constructor(
		public foodId?: number,
		public image?: string,
		public name?: string,
		public category?: string,
		public description?: string,
		public price?: number,
		public address?: Address,
		public ratings?: Rating[]) { }
}
