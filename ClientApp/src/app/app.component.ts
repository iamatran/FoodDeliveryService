import { Component } from '@angular/core';
import { Repository } from './models/repository';
import { Food } from './models/food.model';
import { Address } from './models/address.model';

//This will manage the app-root
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

// We're going to tell the appcomponent class needs a repository object whenever the appcomponent is created
export class AppComponent {
  title = 'Testing';
  constructor(private repo: Repository) { }

  get food(): Food {
    return this.repo.food;
  }
  get foods(): Food[] {
    return this.repo.foods;
  }
  deleteFood() {
    this.repo.deleteFood(1);
  }
  deleteAddress() {
    this.repo.deleteAddress(2);
  }
}
