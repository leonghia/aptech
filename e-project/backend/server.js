const express = require('express');
const cors = require('cors');

const app = express();

let corsOptions = {
    origin: ['http://localhost:8081', 'http://localhost:4200']
};

app.use(cors(corsOptions));

// Parse requests of content-type - application/json
app.use(express.json());

// Parse requests of content-type - application/x-www-form-urlencoded
app.use(express.urlencoded({ extended: true }));


// Allow requests from any origin and with the specified methods and headers
app.use((req, res, next) => {
    res.setHeader('Access-Control-Allow-Origin', '*');
    res.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE');
    res.setHeader('Access-Control-Allow-Headers', 'Content-Type');
    next();
});

// Call sync()
const db = require('./app/models');

db.sequelize.sync();


// Importing routes
const bridgeRoutes = require('./app/routes/bridges.routes');
const reviewRoutes = require('./app/routes/reviews.routes');
const favoritesRoutes = require('./app/routes/favorites.routes');
require('./app/routes/auth.routes')(app);
require('./app/routes/users.routes')(app);

// Call the bridgeRoutes function with the app object
app.use(bridgeRoutes);

// Call the reviewRoutes function with the app object
app.use(reviewRoutes);

// Call the favoritesRoutes function with the app object
app.use(favoritesRoutes);

// Set port, listen for requests
const PORT = process.env.PORT || 8080;
app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
})