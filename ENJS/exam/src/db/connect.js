const mongoose = require("mongoose");
const server = `mongodb://${process.env.DB_HOST}:${process.env.DB_PORT}`;
const db_name = process.env.DB_NAME;
class Database{
    constructor(){
        mongoose.connect(`${server}/${db_name}`)
        .then(()=>{
            console.log(`Connected database ${db_name}`);
        }).catch(err=>{
            console.log(err);
        })
    }
}
module.exports = new Database();