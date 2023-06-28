const config = require('../config/db.config.js');

const Sequelize = require('sequelize');
const sequelize = new Sequelize(
    config.database,
    config.user,
    config.password,
    {
        host: config.host,
        dialect: config.dialect,
        operatorsAliases: false,

        pool: {
            max: config.pool.max,
            min: config.pool.min,
            acquire: config.pool.acquire,
            idle: config.pool.idle
        }
    }
);

const db = {};

db.Sequelize = Sequelize;
db.sequelize = sequelize;

db.user = require('../models/user.model.js')(sequelize, Sequelize);
db.role = require('../models/role.model.js')(sequelize, Sequelize);
db.refreshToken = require("../models/refreshToken.model.js")(sequelize, Sequelize);

db.role.belongsToMany(db.user, {
    through: 'nhom1_users_roles',
    foreignKey: 'role_id',
    otherKey: 'user_id'
});
db.user.belongsToMany(db.role, {
    through: 'nhom1_users_roles',
    foreignKey: 'user_id',
    otherKey: 'role_id'
});

db.refreshToken.belongsTo(db.user, {
    foreignKey: 'user_id', targetKey: 'id'
});
db.user.hasOne(db.refreshToken, {
    foreignKey: 'user_id', targetKey: 'id'
});

db.ROLES = ['user', 'admin', 'moderator'];

module.exports = db;