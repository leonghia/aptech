const express = require('express');
const mysql = require('mysql');
const app = express();

const PORT = process.env.PORT || 5000;

// Config and create a MySQL connection
const configDB = {
    host: 'localhost',
    port: 3306,
    user: 'root',
    password: '',
    database: 'amazing_bridges',
    multipleStatements: true
};
const conn = mysql.createConnection(configDB);

// Define a route for getting all bridges
app.get('/api/bridges', (req, res) => {
    conn.query('SELECT * FROM nhom1_bridges', (error, data) => {
        if (error)
            res.send('Sorry ! 404 not found');
        else
            res.send(data);
    });
})

// Define a route for getting a specific bridge by its ID



// Start the server
app.listen(PORT, function() {
    console.log('Server is running...');
})