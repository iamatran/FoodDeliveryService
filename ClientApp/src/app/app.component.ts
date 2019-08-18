import { Component } from '@angular/core';
import { Repository } from './models/repository';
import { Food } from './models/food.model';

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
}
