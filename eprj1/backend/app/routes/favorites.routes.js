const conn = require('../../db.js');
const router = require('express').Router();

// Define the endpoint for creating new favorite
router.post('/api/favorites', (req, res) => {
    // Get the query parameters from the request
    const bridge_id = req.body.bridge_id;
    const user_id = req.body.user_id;

    // Construct the SQL query based on the query parameters
    let sql = `INSERT INTO nhom1_favorites(user_id, bridge_id) VALUES (${user_id}, ${bridge_id})`;

    // Execute the SQL query using the connection
    conn.query(sql, (error, results) => {
        if (error) {
            throw error;
        } else {
            res.send('Bridge has been successfully added to favorite !');
        }
    })
})

// Define the endpoint for viewing all favorite bridges of a user
router.get('/api/favorites', (req, res) => {
    const user_id = req.query.user_id;
    let sql = `SELECT b.* FROM nhom1_bridges b JOIN nhom1_favorites f ON b.id = f.bridge_id WHERE f.user_id = ${user_id} `;

    conn.query(sql, (error, results) => {
        if (error) {
            throw error;
        } else {
            res.json(results);
        }
    })
})

module.exports = router;