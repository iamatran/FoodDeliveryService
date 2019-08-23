import { Routes, RouterModule } from "@angular/router";
import { FoodSelectionComponent } from "./store/foodSelection.component";
import { CartDetailComponent } from "./store/cartDetail.component";
import { CheckoutDetailsComponent } from "./store/checkout/checkoutDetails.component";
import { CheckoutPaymentComponent } from "./store/checkout/checkoutPayment.component";
import { CheckoutSummaryComponent } from "./store/checkout/checkoutSummary.component";
import { OrderConfirmationComponent } from "./store/checkout/orderConfirmation.component";

//Here we're making routes for our food details so that their URL path can navigate according to the setup below
const routes: Routes = [
    { path: "checkout/step1", component: CheckoutDetailsComponent },
    { path: "checkout/step2", component: CheckoutPaymentComponent },
    { path: "checkout/step3", component: CheckoutSummaryComponent },
    { path: "checkout/confirmation", component: OrderConfirmationComponent },
    { path: "checkout", component: CheckoutDetailsComponent },
    { path: "cart", component: CartDetailComponent },
    { path: "store", component: FoodSelectionComponent  },
    { path: "", component: FoodSelectionComponent  }
]
   
export const RoutingConfig = RouterModule.forRoot(routes);
   