module.exports = {
    secret: 'amazingbridges-secret-key',

    jwtExpiration: 3600, // 1 hour
    jwtRefreshExpiration: 86400, // 24 hour

    /* for test */
    // jwtExpiration: 60,          // 1 minute
    // jwtRefreshExpiration: 120,  // 2 minutes
};