module.exports = {
    secret: 'amazingbridges-secret-key',

    jwtExpiration: 604800, // 7 days
    jwtRefreshExpiration: 2592000, // 30 days

    /* for test */
    // jwtExpiration: 60,          // 1 minute
    // jwtRefreshExpiration: 120,  // 2 minutes
};