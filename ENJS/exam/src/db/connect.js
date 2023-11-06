const mongoose = require("mongoose");
const connectionString = process.env.CONNECTION_STRING;
const db_name = process.env.DB_NAME;
class Database{
    constructor(){
        mongoose.connect(connectionString)
        .then(()=>{
            console.log(`Connected database`);
        }).catch(err=>{
            console.log(err);
        })
    }
}
module.exports = new Database();