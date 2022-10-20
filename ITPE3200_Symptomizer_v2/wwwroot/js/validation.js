function validateName(firstname) {
    const regExp = /^[a-zA-ZæøåÆØÅ. \-]{2,20}$/;
    const ok = regExp.test(firstname);
    if (!ok) {
        $("#failName").html("First Name should consist from 2 upto 20 symbols.");
        return false;
    }
    else {
        $("#failName").html("");
        return true;
    }
}

function validateLastName(lastname) {
    const regExp = /^[a-zA-ZæøåÆØÅ. \-]{2,20}$/;
    const ok = regExp.test(lastname);
    if (!ok) {
        $("#failLastName").html("Last name should consist from 2 upto 20 symbols.");
        return false;
    }
    else {
        $("#failLastName").html("");
        return true;
    }
}

function validateSymptoms(){
    var checkBoxes = $(".form-check-input");
    var checkedSymptoms = [];
    for (let i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].checked) {
            checkedSymptoms.push(checkBoxes[i].value);
        }
        //Requires minimum 1 symptom in combination with method Array.isArray(). This method determines if passed array is an array or not. If passed variable is an array (and not a string f.ex.), this method will return true.
        if (Array.isArray(checkedSymptoms) && !checkedSymptoms.length) {
            $("#fail").html("Please choose minimum 1 symptom!")
        }
    }
}

function validationOK() {
    return validateName($("#firstname").val()) &&
        validateLastName($("#lastname").val()) &&
        validateSymptoms()
}

function validateUserName(username){
    const regExp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regExp.test(username);
    if(!ok){
        $("#failUserName").html("User name should have from 2 upto 20 symbols");
        return false;
    }
    else {
        $("#failUserName").html("");
        return true;
    }
}

function validatePassword(password){
    const regExp = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/;
    //  ^.*(?=.{8,})(?=.*[a-zA-Z])(?=.*\d)(?=.*[!#$%&? "]).*$
    // 
    //  ---
    // 
    //  ^.*              : Start
    //  (?=.{8,})        : Length
    //  (?=.*[a-zA-Z])   : Letters
    //  (?=.*\d)         : Digits
    //  (?=.*[!#$%&? "]) : Special characters
    //  .*$              : End
    const ok = regExp.test(password);
    if(!ok){
        $("#failPassword").html("Password should have minimum 6 symbols");
        return false;
    }
    else {
        $("#failPassword").html("");
        return true;
    }
}

function validateLoggIn(){
    return validateUserName() && validatePassword();
}