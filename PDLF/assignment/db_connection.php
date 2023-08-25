<?php
$servername = "localhost";
$username = "root";
$password = "";
$database = "ecommerce_db"; // Make sure this matches the database name you created

// Create a connection
$conn = new mysqli($servername, $username, $password, $database);

// Check the connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

echo "";

// Don't forget to close the connection when you're done working with the database
// $conn->close();
?>