const searchInput = document.querySelector("#search_product");
const productRows = document.querySelectorAll(".product-row");
const tbody = document.querySelector("tbody");
const header = document.querySelector(".nghia_header");
const tabsContainer = document.querySelector(".nghia-tabs-container");
const tabs = document.querySelectorAll(".nghia-tab-link");
const addProductBtn = document.querySelector(".nghia-add-product-btn");
const dashboard = document.querySelector(".nghia-dashboard");
const addProductForm = document.querySelector(".nghia-add-product-form");
const container = document.querySelector(".nghia-container");
const cancelAddProductBtn = document.querySelector(".nghia-cancel-add-product-btn");
const editProductBtns = document.querySelectorAll(".nghia-edit-product-btn");
const editProductForm = document.querySelector(".nghia-edit-product-form");
const cancelEditProductBtn = document.querySelector(".nghia-cancel-edit-product-btn");

const edit_name_input = document.querySelector("#edit_name");
const edit_description_input = document.querySelector("#edit_description");
const edit_thumbnail_input = document.querySelector("#edit_thumbnail");
const edit_price_input = document.querySelector("#edit_price");
const edit_stock_input = document.querySelector("#edit_stock");
const edit_id_input = document.querySelector("#edit_id");

const delete_id_input = document.querySelector("#delete_id");
const deleteProductModal = document.querySelector("#delete_product_modal");
const cancelDeleteProductBtn = document.querySelector("#cancel_delete_product_btn");
const deleteProductBtns = document.querySelectorAll(".nghia-delete-product-btn");

deleteProductBtns.forEach(btn => btn.addEventListener("click", function(event) {
    const id = event.target.parentElement.parentElement.querySelector(".product-id").textContent;
    delete_id_input.value = id;
    document.querySelector(".nghia-sidebar").classList.add("hidden");
    deleteProductModal.classList.remove("hidden");
}));

cancelDeleteProductBtn.addEventListener("click", function(event) {
    deleteProductModal.classList.add("hidden");
    document.querySelector(".nghia-sidebar").classList.remove("hidden");
});

editProductBtns.forEach(btn => btn.addEventListener("click", function(event) {
    const id = event.target.parentElement.parentElement.querySelector(".product-id").textContent;
    const product = searchProductById(id);
    dashboard.classList.add("hidden");
    editProductForm.classList.remove("hidden");
    container.classList.add("overflow-scroll");
    edit_name_input.value = product.name;
    edit_description_input.value = product.description;
    edit_thumbnail_input.value = product.thumbnail;
    edit_price_input.value = product.price.slice(1);
    edit_stock_input.value = product.stock;
    edit_id_input.value = product.id;
}));

cancelEditProductBtn.addEventListener("click", function() {
    editProductForm.classList.add("hidden");
    container.classList.remove("overflow-scroll");
    dashboard.classList.remove("hidden");
});

cancelAddProductBtn.addEventListener("click", function() {
    addProductForm.classList.add("hidden");
    container.classList.remove("overflow-scroll");
    dashboard.classList.remove("hidden");
});

addProductBtn.addEventListener("click", function() {
    dashboard.classList.add("hidden");
    addProductForm.classList.remove("hidden");
    container.classList.add("overflow-scroll");
});

tabsContainer.addEventListener("click", function(event) {
    const clicked = event.target.closest(".nghia-tab-link");

    if (!clicked) {
        return;
    }

    tabs.forEach(tab => {
        tab.classList.remove("bg-gray-100", "text-indigo-600");
        tab.classList.add("text-gray-700", "hover:text-indigo-600", "hover:bg-gray-100");   
        tab.firstElementChild.classList.remove("text-indigo-600");
        tab.firstElementChild.classList.add("text-gray-400", "group-hover:text-indigo-600");
    });

    clicked.classList.remove("text-gray-700", "hover:text-indigo-600", "hover:bg-gray-100");
    clicked.classList.add("bg-gray-100", "text-indigo-600");
    clicked.firstElementChild.classList.remove("text-gray-400", "group-hover:text-indigo-600");
    clicked.firstElementChild.classList.add("text-indigo-600")
});

const products = [];

productRows.forEach(productRow => {
    const id = productRow.childNodes.item(0).textContent;
    const name = productRow.childNodes.item(1).querySelector(".product-name").textContent;
    const description = productRow.childNodes.item(1).querySelector(".product-description").textContent;
    const thumbnail = productRow.childNodes.item(1).querySelector(".product-thumbnail").src;
    const price = productRow.childNodes.item(2).textContent;
    const stock = productRow.childNodes.item(3).textContent;

    products.push({
        id: id,
        name: name,
        description: description,
        thumbnail: thumbnail,
        price: price,
        stock: stock
    });
});

searchInput.addEventListener("keypress", function(event) {
    if (event.key === "Enter") {
        event.preventDefault();
        const query = searchInput.value;
        if (query === "") {
            displayResult(products);
        } else {
            const result = searchProductByName(query);
            displayResult(result);
        }
    }
});

const searchProductByName = function(query) {
    const result = [];
    products.forEach(product => {
        if (product.name.toLowerCase().includes(query.toLowerCase())) {
            result.push(product);
        }
    });
    return result;
}

const searchProductById = function(id) {
    let result = null;
    products.forEach(product => {
        if (product.id == id) { 
            result = product;          
            return;
        }
    });
    return result;
}

const displayResult = function(products) {
    tbody.innerHTML = "";
    if (products.length === 0) {
        tbody.insertAdjacentHTML("beforeend", "<p class='text-red-500 mt-10 italic'>There is no result matching your search.</p>");
    }
    products.forEach(product => {
        const id = product.id;
        productRows.forEach(productRow => {
            if (productRow.childNodes.item(0).textContent == id) {               
                tbody.insertAdjacentElement("beforeend", productRow);
            }
        })
    });
}