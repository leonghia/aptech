const nodemailer = require("nodemailer");
const config_mail = {
    service: "Gmail",
    host: "smtp.gmail.com",
    port:587,
    auth:{
        user:"hoatq4@fpt.edu.vn",
        pass:"rvlldlldutzkqcmo"
    }
}
const transport = nodemailer.createTransport(config_mail);
module.exports = transport;