import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Food } from "../models/food.model";
import { Address } from "../models/address.model";

@Component({
   templateUrl: "foodAdmin.component.html"
})
export class FoodAdminComponent {
   constructor(private repo: Repository) { }
   tableMode: boolean = true;
   get food(): Food {
       return this.repo.food;
   }
   selectFood(id: number) {
       this.repo.getFood(id);
   }
   saveFood() {
       if (this.repo.food.foodId == null) {
           this.repo.createFood(this.repo.food);
       } else {
           this.repo.replaceFood(this.repo.food);
       }
       this.clearFood()
       this.tableMode = true;
   }
   deleteFood(id: number) {
       this.repo.deleteFood(id);
   }
   clearFood() {
       this.repo.food = new Food();
       this.tableMode = true;
   }
   get foods(): Food[] {
       return this.repo.foods;
   }
}
