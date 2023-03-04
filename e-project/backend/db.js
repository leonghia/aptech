const mysql = require('mysql2');
const configDB = require('./app/config/db.config.js');

const conn = mysql.createConnection(configDB);

module.exports = conn;