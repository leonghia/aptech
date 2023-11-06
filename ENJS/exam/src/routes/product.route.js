const express = require("express");
const router = express.Router();
const productController = require("../controllers/product.controller.js");

// Renderers
router.get("/all", productController.renderAllView);

router.get("/add", productController.renderAddView);

router.get("/update/:id", productController.renderUpdateView);

// APIs
router.get("/api/all", productController.get);

router.get("/api/:id", productController.getById);

router.post("/api", productController.add);

router.put("/api/:id", productController.update);

router.delete("/api/:id", productController.remove);

module.exports = router;