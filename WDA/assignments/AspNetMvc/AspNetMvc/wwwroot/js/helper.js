export const utcToAnotherTimezone = (utcDate = new Date(), offsetHours = 0) => {
    var result = new Date(utcDate);
    result.setHours(utcDate.getHours() + offsetHours);
    return result;
}

export const getStockIconColor = (stock = 0) => {
    if (stock < 50) return "bg-red-700";
    if (stock < 100) return "bg-red-500";
    if (stock < 200) return "bg-orange-500";
    if (stock < 300) return "bg-yellow-300";
    if (stock < 400) return "bg-green-400";
    return "bg-green-500";
}

export const getRatingMarkup = (rating = 0) => {
    const filledStar = `
<svg aria-hidden="true" class="w-5 h-5 text-yellow-400" fill="currentColor" viewbox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
    <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
</svg>
    `;
    const noFilledStar = `
<svg aria-hidden="true" class="w-5 h-5 text-gray-300 dark:text-gray-500" fill="currentColor" viewbox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
    <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
</svg>
    `;
    if (rating < 0.5) return noFilledStar.repeat(5);
    if (rating < 1.5) return filledStar.repeat(1) + noFilledStar.repeat(4);
    if (rating < 2.5) return filledStar.repeat(2) + noFilledStar.repeat(3);
    if (rating < 3.5) return filledStar.repeat(3) + noFilledStar.repeat(2);
    if (rating < 4.5) return filledStar.repeat(4) + noFilledStar.repeat(1);
    return filledStar.repeat(5);
}