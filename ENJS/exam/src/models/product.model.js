const mongoose = require("mongoose");
const product_schema = new mongoose.Schema({
    ProductCode: {
        type: String,
        required:[true,"Trường này bắt buộc phải nhập dữ liệu"],
        minLength:[3,"Độ dài tối thiểu 3"],
        unique:true
    },
    ProductName: {
        type:String,
        required:true,
        minLength:6,
        unique:true,
    },
    ProductDate:{
        type:Date,
        required:true
    },
    ProductOriginPrice: {
        type:Number,
        required:true,
        min: 0
    },
    ProductQuantity: {
        type: Number,
        required:true,
        min: 0
    },
    ProductStoreCode: {
        type: String,
        required:true,
        minLength:3
    }
});
module.exports = mongoose.model("Product",product_schema);