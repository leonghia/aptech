const express = require('express');
const app = express();
const PORT = process.env.PORT || 5000;

const configDB = {
    host: 'localhost',
    port: 3306,
    user: 'root',
    password: '',
    database: 'amazing_bridges',
    multipleStatements: true
};

const mysql = require('mysql2');
const conn = mysql.createConnection(configDB);

app.listen(PORT, function() {
    console.log('Server is running...');
})

app.get('/', function(req, res) {
    res.send('Hello World');
})

app.get('/api/bridges', function(req, res) {
    let sql = "select * from nhom1_bridges";
    conn.query(sql, function(err, data) {
        if (err)
            res.send('404 not found');
        else
            res.send(data);
    });
})