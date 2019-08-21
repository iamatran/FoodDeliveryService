import { Routes, RouterModule } from "@angular/router";
import { FoodTableComponent } from "./structure/foodTable.component"
import { FoodDetailComponent } from "./structure/foodDetail.component";

//Here we're making routes for our food details so that their URL path can navigate according to the setup below
const routes: Routes = [
    { path: "table", component: FoodTableComponent },
    { path: "detail", component: FoodDetailComponent },
    { path: "", component: FoodTableComponent }]
   
export const RoutingConfig = RouterModule.forRoot(routes);
   