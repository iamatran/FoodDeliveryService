import { Routes, RouterModule } from "@angular/router";
import { FoodSelectionComponent } from "./store/foodSelection.component";

//Here we're making routes for our food details so that their URL path can navigate according to the setup below
const routes: Routes = [
    { path: "store", component: FoodSelectionComponent },
    { path: "", component: FoodSelectionComponent }]
   
export const RoutingConfig = RouterModule.forRoot(routes);
   