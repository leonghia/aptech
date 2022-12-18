import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {HomeComponent} from "./pages/home/home.component";
import {CategoryComponent} from "./pages/category/category.component";
import { ProductComponent } from './pages/product/product.component';
import {RouterModule, Routes} from "@angular/router";
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import {HttpClientModule} from "@angular/common/http";
import { CategoriesComponent } from './pages/categories/categories.component';

//1. khai bao danh sach cac routing
const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'categories', component: CategoriesComponent},
  { path: 'categories/:name', component: CategoryComponent },
  { path: 'categories/:name/:id', component: ProductComponent }
]
@NgModule({
  declarations: [
    AppComponent,HomeComponent,CategoryComponent, ProductComponent, LoginComponent, RegisterComponent, CategoriesComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
