//This is our data model with a constructor that can be used to configure a new instance of the class

export class Address {
	constructor(
		public addressId?: number,
		public name?: string,
		public city?: string,
		public state?: string) { }
}