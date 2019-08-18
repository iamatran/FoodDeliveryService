import { Component } from '@angular/core';
import { Repository } from './models/repository';
import { Food } from './models/food.model';
import { Address } from './models/address.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Web Dev';
  constructor(private repo: Repository){}

  get food():Food{
    return this.repo.food;
  }

  get foods():Food[]{
    return this.repo.foods;
  }

  createFood() {
    this.repo.createFood(new Food(0,"bit.ly/2D8C6ha", "X-Men Final Chapter", 
    "Drama", "After the re-emergence of the world's first mutant, " +
    "the world-destroyer Apocalypse, the X-Men must unite to defeat his " +
    "extinction level plan.", 49.99, this.repo.foods[0].address));
  }
  createFoodAndAddress() {
    let s = new Address(0, "SkyTaylor Films", "Brooklyn", "NY");
    let m = new Food(0, "bit.ly/2D7Vtqo", "Chef", "Romance",
      "A head chef quits his restaurant job and buys a food truck", 100, s);
    this.repo.createFoodAndAddress(m, s);
  }

}
