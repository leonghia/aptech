// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// DOM selectors
const navLinks = Array.from(document.querySelectorAll(".nav-link"));

// States
const currentRoute = window.location.href.split("/")[3];
// Function expressions


// Event listeners


// On load
navLinks.forEach(a => {
    if (a.dataset.route.toUpperCase() === currentRoute.toUpperCase()) {
        // hightlight this link
        a.classList.remove(..."text-gray-300 hover:bg-gray-700 hover:text-white".split(" "));
        a.classList.add(..."bg-gray-900 text-white".split(" "));
    }
});
