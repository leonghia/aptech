<?php
include 'db_connection.php'; // Include the database connection file
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $username = $_POST["username"];
    $email = $_POST["email"];
    $password = $_POST["password"];
    $fullName = $_POST["full_name"];
    $role = "admin"; // Default role for new users

    // Hash the password securely before storing
    $hashedPassword = password_hash($password, PASSWORD_DEFAULT);

    // Insert user data into the database
    $sql = "INSERT INTO users (username, email, password, full_name, role, address)
            VALUES ('$username', '$email', '$hashedPassword', '$fullName', '$role', '')";

    if ($conn->query($sql) === TRUE) {
        // Redirect to the success page
        header("Location: register-success.html");
        exit; // Ensure the script stops executing after redirection
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
}
?>
<!-- Your HTML form goes here (see below) -->
<!DOCTYPE html>
<html class="h-full">
<head>
    <title>User Registration</title>
    <script src="https://cdn.tailwindcss.com?plugins=forms,typography,aspect-ratio,line-clamp"></script>
    <script>
        tailwind.config = {
        
        }
    </script>
</head>
<body class="h-full flex justify-center items-center fixed inset-0 bg-gray-500 bg-opacity-25 transition-opacity bg-no-repeat bg-center bg-cover" style="background-image: url(images/background.jpg);">
    <!-- <h2>User Registration</h2>
    <form method="POST" action="register.php">
        <label>Username:</label>
        <input type="text" name="username" required><br>

        <label>Email:</label>
        <input type="email" name="email" required><br>

        <label>Password:</label>
        <input type="password" name="password" required><br>

        <label>Full Name:</label>
        <input type="text" name="full_name"><br>

        <input type="submit" value="Register">
    </form> -->
  
  <div class="h-3/4 w-4/6 shadow-lg bg-white rounded-lg bg-opacity-80 shadow-2xl ring-1 ring-black ring-opacity-5 backdrop-blur backdrop-filter">
  <div class="flex min-h-full">
  <div class="flex flex-1 flex-col justify-center px-4 py-12 sm:px-6 lg:flex-none lg:px-20 xl:px-24">
    <div class="mx-auto w-full max-w-sm lg:w-96">
      <div>
        <img class="h-10 w-auto" src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=600" alt="Your Company">
        <h2 class="mt-8 text-2xl font-bold leading-9 tracking-tight text-gray-900">Register new account</h2>
        <p class="mt-2 text-sm leading-6 text-gray-500">
          Already a member?
          <a href="login.php" class="font-semibold text-indigo-600 hover:text-indigo-500">Login to your account</a>
        </p>
      </div>

      <div class="mt-8">
        <div>
          <form action="register.php" method="POST" class="space-y-6">

            <div>
              <label for="full_name" class="block text-sm font-medium leading-6 text-gray-900">Full name</label>
              <div class="mt-2">
                <input id="full_name" name="full_name" type="text" required class="bg-transparent block w-full rounded-md border-0 py-1.5 shadow-sm ring-1 ring-inset ring-gray-400 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6">
              </div>
            </div>

            <div>
              <label for="username" class="block text-sm font-medium leading-6 text-gray-900">Username</label>
              <div class="mt-2">
                <input id="username" name="username" type="text" required class="bg-transparent block w-full rounded-md border-0 py-1.5 shadow-sm ring-1 ring-inset ring-gray-400 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6">
              </div>
            </div>

            <div>
              <label for="email" class="block text-sm font-medium leading-6 text-gray-900">Email address</label>
              <div class="mt-2">
                <input id="email" name="email" type="email" autocomplete="email" required class="bg-transparent block w-full rounded-md border-0 py-1.5 shadow-sm ring-1 ring-inset ring-gray-400 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6">
              </div>
            </div>

            <div>
              <label for="password" class="block text-sm font-medium leading-6 text-gray-900">Password</label>
              <div class="mt-2">
                <input id="password" name="password" type="password" autocomplete="current-password" required class="bg-transparent block w-full rounded-md border-0 py-1.5 shadow-sm ring-1 ring-inset ring-gray-400 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6">
              </div>
            </div>

            

            <div class="!mt-8">
              <button type="submit" value="Register" class="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Register</button>
            </div>
          </form>
        </div>

        
      </div>
    </div>
  </div>
  <div class="relative hidden w-0 flex-1 lg:block">
  <img class="absolute inset-0 h-full w-full object-cover rounded-r-lg" src="https://images.unsplash.com/photo-1496917756835-20cb06e75b4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1908&q=80" alt="">
  </div>
</div>
  </div>

    
</body>
</html>

