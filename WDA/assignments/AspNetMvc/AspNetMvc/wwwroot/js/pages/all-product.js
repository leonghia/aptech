// Imports
import { getRatingMarkup, getStockIconColor, utcToAnotherTimezone } from "../helper.js";
import { Product } from "../models/product.js";
// DOM selectors
const tableBody = document.querySelector("tbody");
// States and rules
const BASE_URL = "https://localhost:7005/product";
const REGIONS = {
    vietnam: {
        locales: "vi-VN",
        offsetHours: 7
    },
    usa: {
        locales: "en-US"
    }
}

let products;
// Function expressions
const fetchProducts = async () => {
    const response = await fetch(BASE_URL + "/get", {
        method: "GET",
        headers: {
            "Accept": "application/json" 
        },
    });
    const body = await response.json();
    return body.data;
}

const populateProducts = (products = [new Product()]) => {
    tableBody.innerHTML = "";
    products.forEach(p => {
        tableBody.insertAdjacentHTML("beforeend", 
        `
        <tr class="border-b dark:border-gray-600 hover:bg-gray-100 dark:hover:bg-gray-700">
                            <td class="w-4 px-4 py-3">
                                <div class="flex items-center">
                                    <input id="checkbox-table-search-1" type="checkbox" onclick="event.stopPropagation()" class="w-4 h-4 bg-gray-100 border-gray-300 rounded text-primary-600 focus:ring-primary-500 dark:focus:ring-primary-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                                    <label for="checkbox-table-search-1" class="sr-only">checkbox</label>
                                </div>
                            </td>
                            <th scope="row" class="flex items-center px-4 py-2 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                <img src="${p.image}" alt="${p.name}" class="w-auto h-12 mr-3">
                                ${p.name}
                            </th>
                            <td class="px-4 py-2">
                                <span class="bg-primary-100 text-primary-800 text-sm font-medium px-2 py-0.5 rounded dark:bg-primary-900 dark:text-primary-300">${p.category.name}</span>
                            </td>
                            <td class="px-4 py-2 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                <div class="flex items-center">
                                    <div class="inline-block w-4 h-4 mr-2 ${getStockIconColor(p.stock)} rounded-full"></div>
                                    ${p.stock}
                                </div>
                            </td>
                            <td class="px-4 py-2 font-medium text-gray-900 whitespace-nowrap dark:text-white">${p.salesPerDay}</td>
                            <td class="px-4 py-2 font-medium text-gray-900 whitespace-nowrap dark:text-white">${p.salesPerMonth}</td>
                            <td class="px-4 py-2 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                <div class="flex items-center">
                                    ${getRatingMarkup(p.rating)}
                                    <span class="ml-1 text-gray-500 dark:text-gray-400">${p.rating.toFixed(1)}</span>
                                </div>
                            </td>
                            <td class="px-4 py-2 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                <div class="flex items-center">
                                    <svg xmlns="http://www.w3.org/2000/svg" viewbox="0 0 24 24" fill="currentColor" class="w-5 h-5 mr-2 text-gray-400" aria-hidden="true">
                                        <path d="M2.25 2.25a.75.75 0 000 1.5h1.386c.17 0 .318.114.362.278l2.558 9.592a3.752 3.752 0 00-2.806 3.63c0 .414.336.75.75.75h15.75a.75.75 0 000-1.5H5.378A2.25 2.25 0 017.5 15h11.218a.75.75 0 00.674-.421 60.358 60.358 0 002.96-7.228.75.75 0 00-.525-.965A60.864 60.864 0 005.68 4.509l-.232-.867A1.875 1.875 0 003.636 2.25H2.25zM3.75 20.25a1.5 1.5 0 113 0 1.5 1.5 0 01-3 0zM16.5 20.25a1.5 1.5 0 113 0 1.5 1.5 0 01-3 0z" />
                                    </svg>
                                    ${p.sales.toLocaleString(REGIONS.usa.locales)}
                                </div>
                            </td>
                            <td class="px-4 py-2">$${p.revenue.toLocaleString(REGIONS.usa.locales)}</td>
                            <td class="px-4 py-2 font-medium text-gray-900 whitespace-nowrap dark:text-white">${utcToAnotherTimezone(new Date(p.lastUpdate), REGIONS.vietnam.offsetHours).toLocaleString(REGIONS.vietnam.locales)}</td>
                        </tr>
        `);
    });
}

const init = async () => {
    products = await fetchProducts();
    populateProducts(products);
}
// Event listeners

// On load 
init();