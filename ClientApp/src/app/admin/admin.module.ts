import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser"
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { AdminComponent } from "./admin.component";
import { OverviewComponent } from "./overview.component";
import { FoodAdminComponent } from "./foodAdmin.component";
import { OrderAdminComponent } from "./orderAdmin.component";
import { FoodEditorComponent } from "./foodEditor.component";

//This is here to register classes in the decorator for dependency injection
@NgModule({
    imports: [BrowserModule, RouterModule, FormsModule],
    declarations: [AdminComponent, OverviewComponent,
        FoodAdminComponent, OrderAdminComponent, FoodEditorComponent]
})
export class AdminModule { }
