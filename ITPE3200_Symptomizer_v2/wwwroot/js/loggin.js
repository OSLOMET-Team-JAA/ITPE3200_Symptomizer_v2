function loggIn(){
    const usernameOk = validateUserName();
    const passwordOk = validatePassword();
    if(usernameOk && passwordOk){
        const user = {
            username: $("#username").val(),
            password: $("#password").val()
        }
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