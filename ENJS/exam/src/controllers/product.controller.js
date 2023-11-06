const ServerResponse = require("../models/serverResponse.model.js");
const Product = require("../models/product.model.js");

// Renderers
exports.renderAllView = (req, res) => {
    res.render("product/allProductsView");
};

exports.renderAddView = (req, res) => {
    res.render("product/addProductView");
};

exports.renderUpdateView = (req, res) => {
    res.render("product/updateProductView");
};

// APIs
exports.get = async (req, res) => {
    const serverResponse = new ServerResponse();
    const products = await Product.find().limit(20);
    serverResponse.data = products;
    res.status(200).json(serverResponse);
};

exports.getById = async (req, res) => {
    const serverResponse = new ServerResponse();
    const id = req.params.id;
    const product = await Product.findById(id).exec();
    if (product) {
        serverResponse.data = product;
        res.status(200).json(serverResponse);
    } else {
        serverResponse.succeeded = false;
        serverResponse.message = "Product Id not found.";
        res.status(404).json(serverResponse);
    }
};

exports.add = async (req, res) => {
    const serverResponse = new ServerResponse();
    await Product.create(req.body);
    res.status(201).json(serverResponse);
};

exports.update = async (req, res) => {
    const serverResponse = new ServerResponse();
    const id = req.params.id;
    const data = req.body;
    const result = await Product.findByIdAndUpdate(id, data);
    if (result) res.status(200).json(serverResponse);
    else {
        serverResponse.succeeded = false;
        serverResponse.message = "Product Id not found.";
        res.status(404).json(serverResponse);
    }
};

exports.remove = async (req, res) => {
    const serverResponse = new ServerResponse();
    const id = req.params.id;
    const product = await Product.findById(id).exec();
    if (!product) {
        serverResponse.succeeded = false;
        serverResponse.message = "Product Id not found.";
        res.status(404).json(serverResponse);
    } else {
        await Product.findByIdAndDelete(id);
        res.status(200).json(serverResponse);
    }
}

