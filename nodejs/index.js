const express = require("express");
const app = express();
const PORT = process.env.PORT || 5000;

const configDB = {
    host: 'localhost',
    port: 3306,
    user: 'root',
    password: '',
    database: 't2210m',
    multipleStatements: true
};

const mysql = require("mysql");
const conn = mysql.createConnection(configDB);

app.listen(PORT, function() {
    console.log('Server is running...');
})

app.get('/', function(req, res) {
    res.send('Hello World');
})

app.get('/api/product', function(req, res) {
    let sql = "select * from product";
    conn.query(sql, function(err, data) {
        if (err)
            res.send('404 not found');
        else
            res.send(data);
    });
})

app.get('/api/categories', function(req, res) {
    let sql = "select * from categories";
    conn.query(sql, function(err, data) {
        if (err)
            res.send('404 not found');
        else
            res.send(data);
    });
})