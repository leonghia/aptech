const { DataTypes } = require("sequelize");

module.exports = (sequelize, Sequelize) => {
    const User = sequelize.define("users", {
        // Define the attributes based on the schema of the existing table
        first_name: {
            type: DataTypes.STRING
        },
        last_name: {
            type: DataTypes.STRING
        },
        username: {
            type: DataTypes.STRING
        },
        email: {
            type: DataTypes.STRING
        },
        password: {
           type: DataTypes.STRING
        },
        avatar: {
            type: DataTypes.STRING
        }
    }, {
        tableName: 'nhom1_users',
        timestamps: true
    });

    return User;
}