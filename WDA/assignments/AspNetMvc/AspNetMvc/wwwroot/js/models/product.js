import { Category } from "./category.js";

export class Product {
    id = 0;
    name = "";
    category = new Category();
    image = "";
    stock = 0;
    salesPerDay = 0;
    salesPerMonth = 0;
    rating = 0;
    sales = 0;
    revenue = 0;
    lastUpdate = new Date();

    constructor() { }
}