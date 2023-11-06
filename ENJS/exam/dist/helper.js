import { EMAIL_REGEX } from "./config.js";

export const showLoadingSpinner = element => {
    element.classList.add("pointer-events-none");
    element.innerHTML = `
    <svg aria-hidden="true" role="status" class="inline w-6 h-6 mr-3 text-white animate-spin" viewBox="0 0 100 101" fill="none" xmlns="http://www.w3.org/2000/svg">
    <path d="M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z" fill="#E5E7EB"/>
    <path d="M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z" fill="currentColor"/>
    </svg>
    `;
}

export const hideLoadingSpinner = (element, message = null) => {
    element.innerHTML = "";
    element.textContent = message ?? "";
    element.classList.remove("pointer-events-none");
}

const insertErrorMessage = (errorContainer = new HTMLElement(), message = "") => {
    errorContainer.innerHTML = `<p class="text-sm text-red-500">${message}</p>`;
    if (errorContainer.childElementCount > 0) errorContainer.classList.remove("hidden");
}

export const showServerResponse = (serverResponse, container = new HTMLElement(), message = "") => {
    container.innerHTML = `
<div class="flex">
    <div class="flex-shrink-0">
        <svg class="h-5 w-5 text-red-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
            <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.28 7.22a.75.75 0 00-1.06 1.06L8.94 10l-1.72 1.72a.75.75 0 101.06 1.06L10 11.06l1.72 1.72a.75.75 0 101.06-1.06L11.06 10l1.72-1.72a.75.75 0 00-1.06-1.06L10 8.94 8.28 7.22z" clip-rule="evenodd" />
        </svg>
    </div>
    <div class="ml-3">
        <h3 class="text-sm font-medium text-red-800">${message}</h3>
        <div class="mt-2 text-sm text-red-700">
            <p>${serverResponse.message}</p>
        </div>
    </div>
</div>`;
    container.classList.remove("hidden");
}

export const hideServerResponse = (container = new HTMLElement) => container.classList.contains("hidden") || container.classList.add("hidden");

export const validateName = (name = "", nameErrorContainer = null) => {
    let message;
    if (!name) message = "Name must not be empty.";
    else if (name.length < 5) message = "Name must be at least 5 characters.";
    if (nameErrorContainer) insertErrorMessage(nameErrorContainer, message);
    return message;
}

export const validateNumber = (number = 0, numberErrorContainer) => {
    let message;
    if (!number) message = "Please enter a valid number.";
    else if (number <= 0) message = "Number must be greater than zero.";
    if (numberErrorContainer) insertErrorMessage(numberErrorContainer, message);
    return message;
}

export const validateEmail = (email = "", emailErrorContainer = null) => {
    let message;
    if (!email) message = "Email must not be empty.";
    else if (!email.match(EMAIL_REGEX)) message = "Invalid email format.";
    if (emailErrorContainer) insertErrorMessage(emailErrorContainer, message);
    return message;
}

export const validatePassword = (password = "", passwordErrorContainer = null) => {
    let message;
    if (!password) message = "Password must not be empty.";
    else if (password.length < 6) message = "Password must be at least 6 characters.";
    if (passwordErrorContainer) insertErrorMessage(passwordErrorContainer, message);
    return message;
}

export const hideError = errorContainer => errorContainer.classList.add("hidden");