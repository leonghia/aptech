const { DataTypes } = require("sequelize");

module.exports = (sequelize, Sequelize) => {
    const Role = sequelize.define('roles', {
        // Define the attributes based on the schema of the existing table
        name: {
            type: DataTypes.STRING
        }
    }, {
        tableName: 'nhom1_roles',
        timestamps: false
    });

    return Role;
}