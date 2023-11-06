require("dotenv").config();// sẽ sử dụng được file cấu hình .env
const express = require("express");
const app = express(); // host - app
const port = 3306;

app.listen(port,function(){
    console.log("Server is running...");
})
app.set("view engine","ejs");
app.use(express.static("public"));
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
const home_route = require("./src/routes/home.route");
app.use("/",home_route);

const product_route = require("./src/routes/product.route");
app.use("/product", product_route);