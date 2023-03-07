const conn = require('../../db.js');
const router = require('express').Router();

// Define the endpoint for creating new review
router.post('/api/reviews', (req, res) => {
    // Get the query parameters from the request
    const bridge_id = req.body.bridge_id;
    const user_id = req.body.user_id;
    const rating = req.body.rating;
    const content = req.body.content;
    const title = req.body.title;

    // Construct the SQL query based on the query parameters
    let sql = 'INSERT INTO nhom1_reviews(bridge_id, user_id, rating, content, title) VALUES';
    sql += `(${bridge_id}, ${user_id}, ${rating}, '${content}', '${title}')`;

    // Execute the SQL query using the connection
    conn.query(sql, (error, results) => {
        if (error) {
            throw error;
        } else {
            res.send('Review has been succesfully created');
        }
    })
})

// Define the endpoint for viewing all reviews of a specific bridge
router.get('/api/reviews', (req, res) => {
    const bridge_id = req.query.bridge_id;
    let sql = `SELECT u.first_name, u.last_name, u.avatar, r.title, r.content, r.rating, r.createdAt FROM nhom1_reviews r JOIN nhom1_users u ON r.user_id = u.id WHERE r.bridge_id = ${bridge_id}`;

    conn.query(sql, (error, results) => {
        if (error) {
            throw error;
        } else {
            res.json(results);
        }
    })
})

module.exports = router;

    