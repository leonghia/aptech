exports.guest = function(req,res,next){
    if(req.session.auth){
        return res.redirect("/");
    }
    return next();
}

exports.auth = function(req,res,next){
    if(req.session.auth){
        return next();
    }
    return res.redirect("/auth/login");
}