module.exports = {
    host: 'localhost',
    port: 3306,
    user: 'root',
    password: '',
    database: 'amazing_bridges',
    multipleStatements: true,
    dialect: 'mysql',
    pool: {
        max: 5,
        min: 0,
        acquire: 30000,
        idle: 10000
    }
};