const express = require('express');
const mysql = require('mysql');
const app = express();

const PORT = process.env.PORT || 5000;

// Config and create a MySQL connection
const configDB = {
    host: '139.180.186.20',
    port: 3306,
    user: 'demo',
    password: 's(20A5Q.Mvk(bvoP',
    database: 'demo_s1',
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

// Define the endpoint for fetching bridges
app.get('/api/bridges', (req, res) => {

    // Get the query parameters from the request
    const id = req.query.id;
    const continent = req.query.continent;
    const country = req.query.country;
    const material = req.query.material;
    const style = req.query.style;
    const sortBy = req.query.sort;
    const sortOrder = req.query.order || 'asc';
    
    // Construct the SQL query based on the query parameters
    let sql = 'SELECT * FROM nhom1_bridges WHERE 1 = 1';

    if (id) {
        sql += ` AND id = ${id}`;
    }
    if (continent && continent.length !== 0) {
        sql += ` AND continent = '${continent}'`;
    }         
    if (country && country.length !== 0) {
        sql += ` AND country = '${country}'`;
    }
    if (material && material.length !== 0) {
        const materialArr = material.split(',');
        sql += ` AND material IN (${materialArr.map(m => `'${m}'`).join(',')})`;
    }
    if (style && style.length !== 0) {
        const styleArr = style.split(',');
        sql += ` AND style IN (${styleArr.map(s => `'${s}'`).join(',')})`;
    } 
    if (sortBy) {
        sql += ` ORDER BY ${sortBy} ${sortOrder.toUpperCase()}`;
    }  
    
    // Execute the SQL query using the connection
    conn.query(sql, (error, results) => {
        if (error) {
            res.status(500).json({error: 'Error fetching bridges from database'});
        } else if (id) {
            res.json(results[0]);
        } else {
            res.json(results);
        }
    })
})

// Define the endpoint for fetching images
app.get('/api/images', (req, res) => {
    const bridgeId = req.query.bridge_id;
    let sql = `SELECT * FROM nhom1_bridges_images WHERE bridge_id = ${bridgeId}`;

    conn.query(sql, (error, results) => {
        if (error) {
            res.status(500).json({error: 'Error fetching images from database'});
        } else if (results.length === 0) {
            res.status(404).json({error: 'Could not find images with the specified ID'});
        } else {
            res.json(results);
        }   
    })
})

// Define the endpoint for fetching continents
app.get('/api/continents', (req, res) => {
    let sql = 'SELECT DISTINCT continent FROM nhom1_bridges ORDER BY continent';
    conn.query(sql, (error, results) => {
        if (error)
            res.status(500).json({error: 'Error fetching continents from database'});
        else
            res.json(results);
    })
})

// Define the endpoint for fetching countries
app.get('/api/countries', (req, res) => {
    const continent = req.query.continent;
    let sql = `SELECT DISTINCT country FROM nhom1_bridges WHERE continent = '${continent}' ORDER BY country`;
    conn.query(sql, (error, results) => {
        if (error)
            res.status(500).json({error: 'Error fetching countries from database'});
        else
            res.json(results);
    })
})

// Define the endpoint for fetching materials
app.get('/api/materials', (req, res) => {
    let sql = 'SELECT DISTINCT material FROM nhom1_bridges ORDER BY material';
    conn.query(sql, (error, results) => {
        if (error)
            res.status(500).json({error: 'Error fetching materials from database'});
        else
            res.json(results);
    })
})

// Define the endpoint for fetching styles
app.get('/api/styles', (req, res) => {
    let sql = 'SELECT DISTINCT style FROM nhom1_bridges ORDER BY style';
    conn.query(sql, (error, results) => {
        if (error)
            res.status(500).json({error: 'Error fetching styles from database'});
        else
            res.json(results);
    })
})

// Start the server
app.listen(PORT, function () {
    console.log(`Server is running on port ${PORT}`);
})