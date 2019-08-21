import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ModelModule } from './models/model.module';
import { FoodTableComponent } from "./structure/foodTable.component"
import { CategoryFilterComponent } from "./structure/categoryFilter.component"
import { FoodDetailComponent } from "./structure/foodDetail.component";

@NgModule({
  declarations: [
    FoodDetailComponent,
    FoodTableComponent,
    CategoryFilterComponent,
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ModelModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
