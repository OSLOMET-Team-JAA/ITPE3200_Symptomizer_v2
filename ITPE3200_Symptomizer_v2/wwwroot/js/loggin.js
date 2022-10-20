function LoggIn(){
    const usernameOk = validateUserName($("#username").val());
    const passwordOk = validatePassword($("#password").val());
    if(usernameOk && passwordOk){
        const user = {
            username: $("#username").val(),
            password: $("#password").val()
        }
        console.log(user)
        console.log("type of object is not undefined: " + (typeof(user) != 'undefined'))
        $.post("Patient/LoggIn", user, function (ok){
            if(ok){
                window.location.href = 'index.html';
            }else{
                $("#fail").html("Fail to logg in! Check user name or password!")
            }
        }).fail(function(){
            $("#fail").html("Fail on server side - try again later!")
        });
    }
}