<?php
include 'db_connection.php'; // Include the database connection file
session_start(); // Start a new session

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $username = $_POST["username"];
    $password = $_POST["password"];

    // Fetch user data from the database based on the entered username
    $sql = "SELECT id, username, password, full_name, profile_image, role FROM users WHERE username = '$username'";
    $result = $conn->query($sql);

    if ($result->num_rows == 1) {
        $row = $result->fetch_assoc();
        $hashedPassword = $row["password"];

        // Verify the entered password against the hashed password
        if (password_verify($password, $hashedPassword)) {
            $_SESSION["user_id"] = $row["id"];
            $_SESSION["username"] = $row["username"];
            $_SESSION["full_name"] = $row["full_name"];
            $_SESSION["profile_image"] = $row["profile_image"];

            // Redirect to the user dashboard or any other page
            if ($row["role"] == "admin") {
                // Redirect admin to the dashboard page
                header("Location: dashboard.php");
            } else if ($row["role"] == "user") {
                // Redirect other users to the homepage
                header("Location: homepage.php");
            }
            exit;
        } else {
            $loginError = "Invalid password";
        }
    } else {
        $loginError = "User not found";
    }
}
?>
<!DOCTYPE html>
<html class="h-full">
<head>
    <title>User Login</title>
    <script src="https://cdn.tailwindcss.com?plugins=forms,typography,aspect-ratio,line-clamp"></script>
    <script>
        tailwind.config = {
        
        }
    </script>
</head>
<body class="h-full flex justify-center items-center fixed inset-0 bg-gray-500 bg-opacity-25 transition-opacity bg-no-repeat bg-center bg-cover" style="background-image: url(images/background.jpg);">
    <!-- <h2>User Login</h2> -->
    <?php if (isset($loginError)) { ?>
        <p><?php echo $loginError; ?></p>
    <?php } ?>
    <!-- <form method="POST" action="login.php">
        <label>Username:</label>
        <input type="text" name="username" required><br>

        <label>Password:</label>
        <input type="password" name="password" required><br>

        <input type="submit" value="Login">
    </form> -->
    
    <div class="h-3/4 w-4/6 shadow-lg bg-white rounded-lg bg-opacity-80 shadow-2xl ring-1 ring-black ring-opacity-5 backdrop-blur backdrop-filter">
    <div class="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
  <div class="sm:mx-auto sm:w-full sm:max-w-sm">
    <img class="mx-auto h-10 w-auto" src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=600" alt="Your Company">
    <h2 class="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">Sign in to your account</h2>
  </div>

  <div class="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
    <form class="space-y-6" action="login.php" method="POST">
      <div>
        <label for="username" class="block text-sm font-medium leading-6 text-gray-900">Username</label>
        <div class="mt-2">
          <input id="username" name="username" type="text" required class="bg-transparent block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-400 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6">
        </div>
      </div>

      <div>
        <div class="flex items-center justify-between">
          <label for="password" class="block text-sm font-medium leading-6 text-gray-900">Password</label>
          <div class="text-sm">
            <a href="#" class="font-semibold text-indigo-600 hover:text-indigo-500">Forgot password?</a>
          </div>
        </div>
        <div class="mt-2">
          <input id="password" name="password" type="password" autocomplete="current-password" required class="bg-transparent block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-400 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6">
        </div>
      </div>

      <div>
        <button type="submit" value="Login" class="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Sign in</button>
      </div>
    </form>

    <p class="mt-10 text-center text-sm text-gray-500">
      Not a member?
      <a href="register.php" class="font-semibold leading-6 text-indigo-600 hover:text-indigo-500">Register a new account</a>
    </p>
  </div>
</div>
    </div>

    
</body>
</html>