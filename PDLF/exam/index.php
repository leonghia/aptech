<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "library_db";

// Create a connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Query to select all books
$sql = "SELECT * FROM books";
$result = $conn->query($sql);

?>

<!DOCTYPE html>
<html>
<head>
    <title>Library Management</title>
</head>
<body>
    <h1>Library Books</h1>
    <form method="GET" action="">
        <label for="search">Search by Title: </label>
        <input type="text" id="search" name="search">
        <input type="submit" value="Search">
    </form>

    <table border="1">
        <tr>
            <th>ID</th>
            <th>Title</th>
            <th>Author ID</th>
            <th>ISBN</th>
            <th>Publication Year</th>
            <th>Availability</th>
        </tr>
        <?php
        // Display data from the query
        if ($result->num_rows > 0) {
            while ($row = $result->fetch_assoc()) {
                echo "<tr>";
                echo "<td>" . $row["book_id"] . "</td>";
                echo "<td>" . $row["title"] . "</td>";
                echo "<td>" . $row["author_id"] . "</td>";
                echo "<td>" . $row["isbn"] . "</td>";
                echo "<td>" . $row["pub_year"] . "</td>";
                echo "<td>" . ($row["available"] ? "Yes" : "No") . "</td>";
                echo "</tr>";
            }
        } else {
            echo "<tr><td colspan='6'>No books found</td></tr>";
        }
        // Handle search query
if (isset($_GET['search'])) {
    $searchTerm = $_GET['search'];
    $sql = "SELECT * FROM books WHERE title LIKE '%$searchTerm%'";
    $result = $conn->query($sql);
}
        ?>
    </table>
    <h2>Search Results</h2>
    <?php
    // Display search results
    if (isset($result) && $result->num_rows > 0) {
        echo "<table border='1'>";
        echo "<tr><th>ID</th><th>Title</th><th>Author ID</th><th>ISBN</th><th>Publication Year</th><th>Availability</th></tr>";
        while ($row = $result->fetch_assoc()) {
            echo "<tr>";
            echo "<td>" . $row["book_id"] . "</td>";
            echo "<td>" . $row["title"] . "</td>";
            echo "<td>" . $row["author_id"] . "</td>";
            echo "<td>" . $row["isbn"] . "</td>";
            echo "<td>" . $row["pub_year"] . "</td>";
            echo "<td>" . ($row["available"] ? "Yes" : "No") . "</td>";
            echo "</tr>";
        }
        echo "</table>";
    } elseif (isset($_GET['search'])) {
        echo "No results found for '$searchTerm'";
    }
    ?>
    <?php
    // Close the connection
    $conn->close();
    ?>
</body>
</html>