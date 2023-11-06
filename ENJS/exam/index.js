require("dotenv").config();// sẽ sử dụng được file cấu hình .env
const express = require("express");
const app = express(); // host - app
const path = require("path");
const port = 3306;

try
{
    app.listen(port,function(){
        console.log("Server is running...");
    });
    
    app.set('views', path.join(__dirname, './src/views'));
    app.set("view engine","ejs");
    app.use(express.static("dist"));
    app.use(express.json());
    app.use(express.urlencoded({extended:true}));
    // connect database
    require("./src/db/connect");
    // set session
    const session = require("express-session");
    app.use(
        session({
           resave: true,
           saveUninitialized: true,
           secret: process.env.SESSION_SECRET,
           cookie: {
            maxAge: 3600000, // milisecond
            secure: false
           }
        })
    );
    
    // routes
    const product_route = require("./src/routes/product.route");
    app.use("/product", product_route);
} catch (err) {
    console.log("Something went wrong. " + err);
}

