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

// Allow requests from any origin and with the specified methods and headers
app.use((req, res, next) => {
    res.setHeader('Access-Control-Allow-Origin', '*');
    res.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE');
    res.setHeader('Access-Control-Allow-Headers', 'Content-Type');
    next();
});

// Define a route for getting categorized bridges
app.get('/api/bridges/:criteria', (req, res) => {
    const sortBy = req.params.criteria;
    let sql = 'SELECT * FROM nhom1_bridges';

    if (sortBy === 'longest')
        sql += ' ORDER BY length DESC LIMIT 5';
    if (sortBy === 'highest')
        sql += ' ORDER BY height DESC LIMIT 5';
    if (sortBy === 'oldest')
        sql += ' WHERE built_in IS NULL UNION SELECT * FROM nhom1_bridges ORDER BY built_in LIMIT 5';

    conn.query(sql, (error, results) => {
        if (error)
            // Return an error if the query failed
            res.status(500).json({ error: 'Error getting bridges from database' });
        else
            // Return all the bridges if the query succeeds
            res.json(results);
    });
})

// Define a route for getting sorted bridges
app.get('/api/bridges', (req, res) => {
    let sql = 'SELECT * FROM nhom1_bridges';

    // Check if the 'sort' query parameter is present
    if (req.query.sort) {
        // Add an 'ORDER BY' clause to the SQL query to sort by parameter
        sql += ` ORDER BY ${req.query.sort}`;

        // Check if the 'order' query parameter is present and set the sorting order
        if (req.query.order)
            sql += ` ${req.query.order}`;
    }

    conn.query(sql, (error, results) => {
        if (error)
            // Return an error if the query failed
            res.status(500).json({ error: 'Error getting bridges from database' });
        else
            // Return bridges  if the query succeeds
            res.json(results);
    });
});

// Define a route for getting a specific bridge by its ID
app.get('/api/bridge/:id', (req, res) => {
    const bridgeID = req.params.id;

    // Execute a MySQL query to get the bridge with the specified ID
    conn.query('SELECT * FROM nhom1_bridges WHERE id = ?', [bridgeID], (error, results) => {
        if (error) {
            // Return an error if the query failed
            res.status(500).json({ error: 'Error getting bridge from database' });
        } else if (results.length === 0) {
            // Return a 404 error if the bridge was not found
            res.status(404).json({ error: `Bridge with ID ${bridgeID} not found` });
        } else {
            // Return the bridge if it was found
            res.json(results[0]);
        }
    })
})

// Define a route for getting images
app.get('/api/bridge-images/:criteria', (req, res) => {
    const filterBy = req.params.criteria;
    let sql = 'SELECT * FROM nhom1_bridges_images';

    if (filterBy !== 'all')
        sql += ` WHERE bridge_id = ${filterBy}`;

    conn.query(sql, (error, results) => {
        if (error)
            // Return an error if the query failed
            res.status(500).json({ error: 'Error getting bridges from database' });
        else if (results.length === 0)
            // Return a 404 error if the images were not found
            res.status(404).json({ error: 'Images could not be found' });
        else
            // Return the images if the query succeeds
            res.json(results);
    })
    
})


// Start the server
app.listen(PORT, function () {
    console.log('Server is running...');
})