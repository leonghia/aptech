const conn = require('../../db.js');
const router = require('express').Router();

// Define the endpoint for fetching bridges
router.get('/api/bridges', (req, res) => {
    // Get the query parameters from the request
    const id = req.query.id;
    const continent = req.query.continent;
    const country = req.query.country;
    const q = req.query.q;
    const material = req.query.material;
    const style = req.query.style;
    const sortBy = req.query.sort || 'name';
    const sortOrder = req.query.order || 'asc';
    const limit = req.query.limit;
    
    // Construct the SQL query based on the query parameters
    let sql = 'SELECT b.*, COUNT(r.id) AS review_count, ROUND(AVG(r.rating)) AS average_rating, SUM(r.rating = 1) AS one_star_reviews, SUM(r.rating = 2) AS two_star_reviews, SUM(r.rating = 3) AS three_star_reviews, SUM(r.rating = 4) AS four_star_reviews, SUM(r.rating = 5) AS five_star_reviews FROM nhom1_bridges b LEFT JOIN nhom1_reviews r ON b.id = r.bridge_id WHERE 1 = 1';

    if (id) {
        sql += ` AND b.id = ${id}`;
    }
    if (continent) {
        sql += ` AND continent = '${continent}'`;
    }         
    if (country) {
        sql += ` AND country = '${country}'`;
    }
    if (q) {
        sql += ` AND name LIKE '%${q}%'`;
    }
    if (material) {
        const materialArr = material.split(',');
        sql += ` AND material IN (${materialArr.map(m => `'${m}'`).join(',')})`;
    }
    if (style) {
        const styleArr = style.split(',');
        sql += ` AND style IN (${styleArr.map(s => `'${s}'`).join(',')})`;
    } 

    sql += ' GROUP BY b.id';

    if (sortBy) {
        sql += ` ORDER BY ${sortBy} ${sortOrder.toUpperCase()}`;
    }
    if (limit) {
        sql += ` LIMIT ${limit}`;
    } 
    
    
    // Execute the SQL query using the connection
    conn.query(sql, (error, results) => {
        if (error) {
            console.log(sql);
        } else if (id) {
            res.json(results[0]);
        } else {
            res.json(results);
        }
    })
});

// Define the endpoint for fetching images
router.get('/api/images', (req, res) => {
    const bridgeId = req.query.bridge_id;
    let sql = `SELECT * FROM nhom1_bridges_images WHERE bridge_id = ${bridgeId}`;

    conn.query(sql, (error, results) => {
        if (error) {
            res.status(500).json({error: 'Error fetching images from database'});
        } else if (results.length === 0) {
            res.status(404).json({error: 'Could not find images with the specified ID'});
        } else {
            res.json(results);
        }   
    })
})

// Define the endpoint for fetching continents
router.get('/api/continents', (req, res) => {
    let sql = 'SELECT DISTINCT continent FROM nhom1_bridges ORDER BY continent';
    conn.query(sql, (error, results) => {
        if (error)
            res.status(500).json({error: 'Error fetching continents from database'});
        else
            res.json(results);
    })
})

// Define the endpoint for fetching countries
router.get('/api/countries', (req, res) => {
    const continent = req.query.continent;
    let sql = `SELECT DISTINCT country FROM nhom1_bridges WHERE continent = '${continent}' ORDER BY country`;
    conn.query(sql, (error, results) => {
        if (error)
            res.status(500).json({error: 'Error fetching countries from database'});
        else
            res.json(results);
    })
})

// Define the endpoint for fetching materials
router.get('/api/materials', (req, res) => {
    let sql = 'SELECT DISTINCT material FROM nhom1_bridges ORDER BY material';
    conn.query(sql, (error, results) => {
        if (error)
            res.status(500).json({error: 'Error fetching materials from database'});
        else
            res.json(results);
    })
})

// Define the endpoint for fetching styles
router.get('/api/styles', (req, res) => {
    let sql = 'SELECT DISTINCT style FROM nhom1_bridges ORDER BY style';
    conn.query(sql, (error, results) => {
        if (error)
            res.status(500).json({error: 'Error fetching styles from database'});
        else
            res.json(results);
    })
})

module.exports = router;