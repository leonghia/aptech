exports.min_age_18 = function(req,res,next){
    if(req.session.auth){
        const u = req.session.auth;
        if(u.age >=18){
            return next();
        }
    }
    return res.redirect("/");
}