<?php
include 'db_connection.php'; // Include the database connection file
session_start();
// Query to select all products
$sql = "SELECT * FROM products";
$result = $conn->query($sql);

if ($_SERVER["REQUEST_METHOD"] == "POST") {

  if ($_POST['temp'] == "add") {
    $name = $_POST["name"];
  $description = $_POST["description"];
  $price = $_POST["price"];
  $stock = $_POST["stock"];

  // Insert product data into the database
  $sql = "INSERT INTO products (name, description, price, stock)
          VALUES ('$name', '$description', $price, $stock)";

  if ($conn->query($sql) === TRUE) {
      
      header("Location: dashboard.php");
      exit; // Ensure the script stops executing after redirection
  } else {
      echo "Error: " . $sql . "<br>" . $conn->error;
  }
  } else if ($_POST['temp'] == "update") {
    $id = $_POST["edit_id"];
  $name = $_POST["edit_name"];
  $description = $_POST["edit_description"];
  $thumbnail = $_POST["edit_thumbnail"];
  $price = $_POST["edit_price"];
  $stock = $_POST["edit_stock"];

  // Insert product data into the database
  $sql = "UPDATE products SET name = '$name', description = '$description', thumbnail = '$thumbnail', price = $price, stock = $stock
          WHERE id = $id";

  if ($conn->query($sql) === TRUE) {
      
      header("Location: dashboard.php");
      exit; // Ensure the script stops executing after redirection
  } else {
      echo "Error: " . $sql . "<br>" . $conn->error;
  }
  } else if ($_POST['temp'] == "delete") {
    $id = $_POST["delete_id"];
    
    $sql = "DELETE FROM products WHERE id = $id";

    if ($conn->query($sql) === TRUE) {
      
      header("Location: dashboard.php");
      exit; // Ensure the script stops executing after redirection
  } else {
      echo "Error: " . $sql . "<br>" . $conn->error;
  }
  }

  
}

?>

<!DOCTYPE html>
<html class="h-full">
<head>
    <title>Dashboard</title>
    <script src="https://cdn.tailwindcss.com?plugins=forms,typography,aspect-ratio,line-clamp"></script>
    <script>
        tailwind.config = {
        
        }
    </script>
    <script src="admin.js" defer></script>
</head>
<body class="h-full flex justify-center items-center fixed inset-0 bg-gray-500 bg-opacity-25 transition-opacity bg-no-repeat bg-center bg-cover" style="background-image: url(images/background.jpg);">

    <div class="h-3/4 w-4/6 shadow-lg bg-white rounded-lg bg-opacity-80 shadow-2xl ring-1 ring-black ring-opacity-5 backdrop-blur backdrop-filter nghia-container">

    <div id="delete_product_modal" class="hidden relative z-10" aria-labelledby="modal-title" role="dialog" aria-modal="true">
    <!--
      Background backdrop, show/hide based on modal state.
  
      Entering: "ease-out duration-300"
        From: "opacity-0"
        To: "opacity-100"
      Leaving: "ease-in duration-200"
        From: "opacity-100"
        To: "opacity-0"
    -->
    <div class="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity"></div>
  
    <div class="fixed inset-0 z-10 overflow-y-auto">
      <div class="flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:p-0">
        <!--
          Modal panel, show/hide based on modal state.
  
          Entering: "ease-out duration-300"
            From: "opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95"
            To: "opacity-100 translate-y-0 sm:scale-100"
          Leaving: "ease-in duration-200"
            From: "opacity-100 translate-y-0 sm:scale-100"
            To: "opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95"
        -->
        
        <form action="dashboard.php" method="POST" class="relative transform overflow-hidden rounded-lg bg-white text-left shadow-xl transition-all sm:my-8 sm:w-full sm:max-w-lg">
          <input type="text" name="temp" value="delete" class="hidden">
          <input type="text" name="delete_id" id="delete_id" class="hidden">
          <div class="bg-white px-4 pb-4 pt-5 sm:p-6 sm:pb-4">
            <div class="sm:flex sm:items-start">
              <div class="mx-auto flex h-12 w-12 flex-shrink-0 items-center justify-center rounded-full bg-red-100 sm:mx-0 sm:h-10 sm:w-10">
                <svg class="h-6 w-6 text-red-600" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                  <path stroke-linecap="round" stroke-linejoin="round" d="M12 9v3.75m-9.303 3.376c-.866 1.5.217 3.374 1.948 3.374h14.71c1.73 0 2.813-1.874 1.948-3.374L13.949 3.378c-.866-1.5-3.032-1.5-3.898 0L2.697 16.126zM12 15.75h.007v.008H12v-.008z" />
                </svg>
              </div>
              <div class="mt-3 text-center sm:ml-4 sm:mt-0 sm:text-left">
                <h3 class="text-base font-semibold leading-6 text-gray-900" id="modal-title">Delete product</h3>
                <div class="mt-2">
                  <p class="text-sm text-gray-500">Are you sure you want to delete this product? All of its data will be permanently removed from the database. This action cannot be undone.</p>
                </div>
              </div>
            </div>
          </div>
          <div class="bg-gray-50 px-4 py-3 sm:flex sm:flex-row-reverse sm:px-6">
            <button type="submit" class="inline-flex w-full justify-center rounded-md bg-red-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-red-500 sm:ml-3 sm:w-auto">Delete</button>
            <button type="button" id="cancel_delete_product_btn" class="mt-3 inline-flex w-full justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:mt-0 sm:w-auto">Cancel</button>
          </div>
      </form>
      </div>
    </div>
  </div>

  

    <form action="dashboard.php" method="POST" class="nghia-add-product-form hidden py-10 px-12">
        <input type="text" name="temp" value="add" class="hidden">
  <div class="space-y-12 sm:space-y-16">
    <div>
      <h2 class="text-base font-semibold leading-7 text-gray-900">Add product</h2>
      <p class="mt-1 max-w-2xl text-sm leading-6 text-gray-600">Add a new product to your database. Please fill in all the required fields.</p>

      <div class="mt-10 space-y-8 border-b border-gray-900/10 pb-12 sm:space-y-0 sm:divide-y sm:divide-gray-900/10 sm:border-t sm:pb-0">
        <div class="sm:grid sm:grid-cols-3 sm:items-start sm:gap-4 sm:py-6">
          <label for="name" class="block text-sm font-medium leading-6 text-gray-900 sm:pt-1.5">Product name</label>
          <div class="mt-2 sm:col-span-2 sm:mt-0">
            <div class="flex rounded-md shadow-sm ring-1 ring-inset ring-gray-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 sm:max-w-md">
              
              <input type="text" name="name" id="name" autocomplete="name" class="block flex-1 border-0 bg-transparent py-1.5 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6 ring-gray-400 ring-1 ring-inset rounded-md">
            </div>
          </div>
        </div>

        <div class="sm:grid sm:grid-cols-3 sm:items-start sm:gap-4 sm:py-6">
          <label for="description" class="block text-sm font-medium leading-6 text-gray-900 sm:pt-1.5">Description</label>
          <div class="mt-2 sm:col-span-2 sm:mt-0">
            <textarea id="description" name="description" rows="3" class="ring-gray-400 bg-transparent block w-full max-w-2xl rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"></textarea>
            <p class="mt-3 text-sm leading-6 text-gray-600">Write a few sentences about the product's features.</p>
          </div>
        </div>

        <div class="sm:grid sm:grid-cols-3 sm:items-start sm:gap-4 sm:py-6">
          <label for="price" class="block text-sm font-medium leading-6 text-gray-900 sm:pt-1.5">Product price ($)</label>
          <div class="mt-2 sm:col-span-2 sm:mt-0">
            <div class="flex rounded-md shadow-sm ring-1 ring-inset ring-gray-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 sm:max-w-md">
              
              <input type="text" name="price" id="price" autocomplete="price" class="block flex-1 border-0 bg-transparent py-1.5 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6 ring-gray-400 ring-1 ring-inset rounded-md">
            </div>
          </div>
        </div>

        <div class="sm:grid sm:grid-cols-3 sm:items-start sm:gap-4 sm:py-6">
          <label for="stock" class="block text-sm font-medium leading-6 text-gray-900 sm:pt-1.5">Product stock</label>
          <div class="mt-2 sm:col-span-2 sm:mt-0">
            <div class="flex rounded-md shadow-sm ring-1 ring-inset ring-gray-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 sm:max-w-md">
              
              <input type="text" name="stock" id="stock" autocomplete="stock" class="block flex-1 border-0 bg-transparent py-1.5 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6 ring-gray-400 ring-1 ring-inset rounded-md">
            </div>
          </div>
        </div>

      </div>
    </div>

    
  </div>

  <div class="mt-6 flex items-center justify-end gap-x-6">
    <button type="button" class="text-sm font-semibold leading-6 text-gray-900 nghia-cancel-add-product-btn">Cancel</button>
    <button type="submit" class="inline-flex justify-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Save</button>
  </div>
</form>

<form action="dashboard.php" method="POST" class="nghia-edit-product-form hidden py-10 px-12">
<input type="text" name="temp" value="update" class="hidden">
  <div class="space-y-12 sm:space-y-16">
    <div>
      <h2 class="text-base font-semibold leading-7 text-gray-900">Edit product</h2>
      <p class="mt-1 max-w-2xl text-sm leading-6 text-gray-600">Edit an existing product in your database. Please fill in all the required fields.</p>

      <div class="mt-10 space-y-8 border-b border-gray-900/10 pb-12 sm:space-y-0 sm:divide-y sm:divide-gray-900/10 sm:border-t sm:pb-0">
        <div class="sm:grid sm:grid-cols-3 sm:items-start sm:gap-4 sm:py-6">
          <label for="edit_name" class="block text-sm font-medium leading-6 text-gray-900 sm:pt-1.5">Product name</label>
          <div class="mt-2 sm:col-span-2 sm:mt-0">
            <div class="flex rounded-md shadow-sm ring-1 ring-inset ring-gray-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 sm:max-w-md">
              
              <input type="text" name="edit_name" id="edit_name" autocomplete="name" class="block flex-1 border-0 bg-transparent py-1.5 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6 ring-gray-400 ring-1 ring-inset rounded-md">
            </div>
          </div>
        </div>

        <div class="hidden">
          <label for="edit_id" class="block text-sm font-medium leading-6 text-gray-900 sm:pt-1.5">Product Id</label>
          <div class="mt-2 sm:col-span-2 sm:mt-0">
            <div class="flex rounded-md shadow-sm ring-1 ring-inset ring-gray-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 sm:max-w-md">
              
              <input type="text" name="edit_id" id="edit_id" autocomplete="edit_id" class="block flex-1 border-0 bg-transparent py-1.5 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6 ring-gray-400 ring-1 ring-inset rounded-md">
            </div>
          </div>
        </div>

        <div class="sm:grid sm:grid-cols-3 sm:items-start sm:gap-4 sm:py-6">
          <label for="edit_description" class="block text-sm font-medium leading-6 text-gray-900 sm:pt-1.5">Description</label>
          <div class="mt-2 sm:col-span-2 sm:mt-0">
            <textarea id="edit_description" name="edit_description" rows="3" class="ring-gray-400 bg-transparent block w-full max-w-2xl rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"></textarea>
            <p class="mt-3 text-sm leading-6 text-gray-600">Write a few sentences about the product's features.</p>
          </div>
        </div>

        <div class="sm:grid sm:grid-cols-3 sm:items-start sm:gap-4 sm:py-6">
          <label for="edit_thumbnail" class="block text-sm font-medium leading-6 text-gray-900 sm:pt-1.5">Product thumbnail</label>
          <div class="mt-2 sm:col-span-2 sm:mt-0">
            <div class="flex rounded-md shadow-sm ring-1 ring-inset ring-gray-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 sm:max-w-md">
              
              <input type="text" name="edit_thumbnail" id="edit_thumbnail" autocomplete="edit_thumbnail" class="block flex-1 border-0 bg-transparent py-1.5 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6 ring-gray-400 ring-1 ring-inset rounded-md">
            </div>
          </div>
        </div>

        <div class="sm:grid sm:grid-cols-3 sm:items-start sm:gap-4 sm:py-6">
          <label for="edit_price" class="block text-sm font-medium leading-6 text-gray-900 sm:pt-1.5">Product price ($)</label>
          <div class="mt-2 sm:col-span-2 sm:mt-0">
            <div class="flex rounded-md shadow-sm ring-1 ring-inset ring-gray-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 sm:max-w-md">
              
              <input type="text" name="edit_price" id="edit_price" autocomplete="edit_price" class="block flex-1 border-0 bg-transparent py-1.5 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6 ring-gray-400 ring-1 ring-inset rounded-md">
            </div>
          </div>
        </div>

        <div class="sm:grid sm:grid-cols-3 sm:items-start sm:gap-4 sm:py-6">
          <label for="edit_stock" class="block text-sm font-medium leading-6 text-gray-900 sm:pt-1.5">Product stock</label>
          <div class="mt-2 sm:col-span-2 sm:mt-0">
            <div class="flex rounded-md shadow-sm ring-1 ring-inset ring-gray-300 focus-within:ring-2 focus-within:ring-inset focus-within:ring-indigo-600 sm:max-w-md">
              
              <input type="text" name="edit_stock" id="edit_stock" autocomplete="edit_stock" class="block flex-1 border-0 bg-transparent py-1.5 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6 ring-gray-400 ring-1 ring-inset rounded-md">
            </div>
          </div>
        </div>

      </div>
    </div>

    
  </div>

  <div class="mt-6 flex items-center justify-end gap-x-6">
    <button type="button" class="text-sm font-semibold leading-6 text-gray-900 nghia-cancel-edit-product-btn">Cancel</button>
    <button type="submit" class="inline-flex justify-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Save</button>
  </div>
</form>

    <div class="flex h-full nghia-dashboard">
  

  <!-- Static sidebar for desktop -->
  <div class="hidden lg:inset-y-0 lg:z-50 lg:flex lg:w-72 lg:flex-col">
    <!-- Sidebar component, swap this element with another sidebar if you like -->
    <div class="nghia-sidebar flex grow flex-col gap-y-5 overflow-y-auto border-r border-gray-500 border-opacity-10 px-6 rounded-l-lg">
      <div class="flex h-16 shrink-0 items-center">
        <img class="h-8 w-auto" src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=600" alt="Your Company">
      </div>
      <nav class="flex flex-1 flex-col">
        <ul role="list" class="flex flex-1 flex-col gap-y-7">
          <li>
            <ul role="list" class="-mx-2 space-y-1 nghia-tabs-container">
              <li>
                <!-- Current: "bg-gray-50 text-indigo-600", Default: "text-gray-700 hover:text-indigo-600 hover:bg-gray-50" -->
                <a href="#" class="bg-gray-100 text-indigo-600 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold nghia-tab-link">
                  <svg class="h-6 w-6 shrink-0 text-indigo-600" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                    <path stroke-linecap="round" stroke-linejoin="round" d="M2.25 12l8.954-8.955c.44-.439 1.152-.439 1.591 0L21.75 12M4.5 9.75v10.125c0 .621.504 1.125 1.125 1.125H9.75v-4.875c0-.621.504-1.125 1.125-1.125h2.25c.621 0 1.125.504 1.125 1.125V21h4.125c.621 0 1.125-.504 1.125-1.125V9.75M8.25 21h8.25" />
                  </svg>
                  Dashboard
                </a>
              </li>
              <!-- <li>
                <a href="#" class="text-gray-700 hover:text-indigo-600 hover:bg-gray-50 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold nghia-tab-link">
                  <svg class="h-6 w-6 shrink-0 text-gray-400 group-hover:text-indigo-600" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                    <path stroke-linecap="round" stroke-linejoin="round" d="M15 19.128a9.38 9.38 0 002.625.372 9.337 9.337 0 004.121-.952 4.125 4.125 0 00-7.533-2.493M15 19.128v-.003c0-1.113-.285-2.16-.786-3.07M15 19.128v.106A12.318 12.318 0 018.624 21c-2.331 0-4.512-.645-6.374-1.766l-.001-.109a6.375 6.375 0 0111.964-3.07M12 6.375a3.375 3.375 0 11-6.75 0 3.375 3.375 0 016.75 0zm8.25 2.25a2.625 2.625 0 11-5.25 0 2.625 2.625 0 015.25 0z" />
                  </svg>
                  Team
                </a>
              </li>
              <li>
                <a href="#" class="text-gray-700 hover:text-indigo-600 hover:bg-gray-50 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold nghia-tab-link">
                  <svg class="h-6 w-6 shrink-0 text-gray-400 group-hover:text-indigo-600" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                    <path stroke-linecap="round" stroke-linejoin="round" d="M2.25 12.75V12A2.25 2.25 0 014.5 9.75h15A2.25 2.25 0 0121.75 12v.75m-8.69-6.44l-2.12-2.12a1.5 1.5 0 00-1.061-.44H4.5A2.25 2.25 0 002.25 6v12a2.25 2.25 0 002.25 2.25h15A2.25 2.25 0 0021.75 18V9a2.25 2.25 0 00-2.25-2.25h-5.379a1.5 1.5 0 01-1.06-.44z" />
                  </svg>
                  Products
                </a>
              </li>
              <li>
                <a href="#" class="text-gray-700 hover:text-indigo-600 hover:bg-gray-50 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold nghia-tab-link">
                  <svg class="h-6 w-6 shrink-0 text-gray-400 group-hover:text-indigo-600" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                    <path stroke-linecap="round" stroke-linejoin="round" d="M6.75 3v2.25M17.25 3v2.25M3 18.75V7.5a2.25 2.25 0 012.25-2.25h13.5A2.25 2.25 0 0121 7.5v11.25m-18 0A2.25 2.25 0 005.25 21h13.5A2.25 2.25 0 0021 18.75m-18 0v-7.5A2.25 2.25 0 015.25 9h13.5A2.25 2.25 0 0121 11.25v7.5" />
                  </svg>
                  Calendar
                </a>
              </li>
              <li>
                <a href="#" class="text-gray-700 hover:text-indigo-600 hover:bg-gray-50 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                  <svg class="h-6 w-6 shrink-0 text-gray-400 group-hover:text-indigo-600" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                    <path stroke-linecap="round" stroke-linejoin="round" d="M15.75 17.25v3.375c0 .621-.504 1.125-1.125 1.125h-9.75a1.125 1.125 0 01-1.125-1.125V7.875c0-.621.504-1.125 1.125-1.125H6.75a9.06 9.06 0 011.5.124m7.5 10.376h3.375c.621 0 1.125-.504 1.125-1.125V11.25c0-4.46-3.243-8.161-7.5-8.876a9.06 9.06 0 00-1.5-.124H9.375c-.621 0-1.125.504-1.125 1.125v3.5m7.5 10.375H9.375a1.125 1.125 0 01-1.125-1.125v-9.25m12 6.625v-1.875a3.375 3.375 0 00-3.375-3.375h-1.5a1.125 1.125 0 01-1.125-1.125v-1.5a3.375 3.375 0 00-3.375-3.375H9.75" />
                  </svg>
                  Documents
                </a>
              </li>
              <li>
                <a href="#" class="text-gray-700 hover:text-indigo-600 hover:bg-gray-50 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                  <svg class="h-6 w-6 shrink-0 text-gray-400 group-hover:text-indigo-600" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                    <path stroke-linecap="round" stroke-linejoin="round" d="M10.5 6a7.5 7.5 0 107.5 7.5h-7.5V6z" />
                    <path stroke-linecap="round" stroke-linejoin="round" d="M13.5 10.5H21A7.5 7.5 0 0013.5 3v7.5z" />
                  </svg>
                  Reports
                </a>
              </li> -->
            </ul>
          </li>
          
          <li class="-mx-6 mt-auto">
            <a href="#" class="flex items-center gap-x-4 px-6 py-3 text-sm font-semibold leading-6 text-gray-900 hover:bg-gray-50">
              <img class="h-8 w-8 rounded-full bg-gray-50" src="<?php echo $_SESSION["profile_image"]; ?>" alt="">
              <span class="sr-only">Your profile</span>
              <span aria-hidden="true"><?php echo $_SESSION["full_name"]; ?></span>
            </a>
          </li>
        </ul>
      </nav>
    </div>
  </div>

  <div class="sticky top-0 z-40 flex items-center gap-x-6 bg-white px-4 py-4 shadow-sm sm:px-6 lg:hidden">
    <button type="button" class="-m-2.5 p-2.5 text-gray-700 lg:hidden">
      <span class="sr-only">Open sidebar</span>
      <svg class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
        <path stroke-linecap="round" stroke-linejoin="round" d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5" />
      </svg>
    </button>
    <div class="flex-1 text-sm font-semibold leading-6 text-gray-900">Dashboard</div>
    <a href="#">
      <span class="sr-only">Your profile</span>
      <img class="h-8 w-8 rounded-full bg-gray-50" src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80" alt="">
    </a>
  </div>

  <main class="py-10 overflow-scroll rounded-r-lg">
    
    <div class="px-4 sm:px-6 lg:px-8">
  <div class="sm:flex sm:items-center">
    <div class="sm:flex-auto">
      <h1 class="text-base font-semibold leading-6 text-gray-900 nghia_header">Products</h1>
      <p class="mt-2 text-sm text-gray-700">A list of all the products in your database including their name, description, price and stock.</p>
    </div>
    <div class="mt-4 sm:ml-16 sm:mt-0 sm:flex-none">
    
  <div class="relative flex items-center">
    <input id="search_product" type="text" placeholder="Search..." name="search" id="search" class="bg-transparent block w-full rounded-md border-0 py-1.5 pr-14 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6">
    <div class="absolute inset-y-0 right-0 flex py-1.5 pr-1.5">
      <kbd class="inline-flex items-center rounded border border-gray-200 px-1 font-sans text-xs text-gray-400">⌘K</kbd>
    </div>
  </div>
    </div>
    <div class="mt-4 sm:ml-16 sm:mt-0 sm:flex-none">
      <button type="button" class="block rounded-md bg-indigo-600 px-3 py-2 text-center text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600 nghia-add-product-btn">Add product</button>
    </div>
  </div>
  <div class="mt-8 flow-root">
    <div class="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
      <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8">
        <table class="min-w-full divide-y divide-gray-300">
          <thead>
            <tr>
            <th scope="col" class="py-3.5 pl-4 pr-8 text-left text-sm font-semibold text-gray-900 sm:pl-0">ID</th>
              <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-gray-900 w-[500px]">Name</th>
              <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-gray-900">Price</th>
              <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-gray-900">Stock</th>
              <!-- <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-gray-900">Role</th> -->
              <th scope="col" class="relative py-3.5 px-5">
                <span class="sr-only">Edit</span>
              </th>
              <th scope="col" class="relative py-3.5 pl-5 pr-4 sm:pr-0">
                <span class="sr-only">Delete</span>
              </th>
            </tr>
          </thead>
          <tbody class="divide-y divide-gray-500 divide-opacity-10">
      
          <?php
        // Display data from the query
        if ($result->num_rows > 0) {
            while ($row = $result->fetch_assoc()) {
                echo "<tr class='product-row'>";
                echo "<td class='whitespace-nowrap py-5 pl-4 pr-8 text-sm sm:pl-0 text-gray-700 product-id'>" . $row["id"] . "</td>";
                echo "<td class='whitespace-nowrap px-3 py-5 text-sm w-[500px]'><div class='flex items-center'>
                <div class='h-11 w-11 flex-shrink-0'>
                  <img alt='' class='h-11 w-11 rounded-full product-thumbnail' src=" . $row["thumbnail"] . ">
                </div>
                <div class='ml-4'>
                  <div class='font-medium text-gray-900 product-name'>" . $row["name"] . "</div>
                  <div class='mt-1 text-gray-700 product-description whitespace-normal product-description'>" . $row["description"] . "</div>
                </div>
              </div></td>";
                echo "<td class='whitespace-nowrap px-3 py-5 text-sm text-gray-700 product-price'>$" . $row["price"] . "</td>";
                
                echo "<td class='whitespace-nowrap px-3 py-5 text-sm text-gray-700 product-stock'>" . $row["stock"] . "</td>"; 
                echo "<td class='relative whitespace-nowrap py-5 px-5 text-right text-sm font-medium'>
                <a href='#' class='text-indigo-600 hover:text-indigo-900 nghia-edit-product-btn'>Edit<span class='sr-only'>, Lindsay Walton</span></a>
              </td>";      
                echo "<td class='relative whitespace-nowrap py-5 pl-5 pr-4 text-right text-sm font-medium sm:pr-0'>
                <a href='#' class='text-red-600 hover:text-red-700 nghia-delete-product-btn'>Delete<span class='sr-only'>, Lindsay Walton</span></a>
                </td>";           
                echo "</tr>";
            }
        } else {
            echo "<tr><td colspan='6'>No books found</td></tr>";
        }
        ?>       
          </tbody>
        </table>
      </div>
    </div>
  </div>
</div>   
    
  </main>
</div>

     
    </div>


    
    <?php
    // Close the connection
    $conn->close();
    ?>
</body>
</html>