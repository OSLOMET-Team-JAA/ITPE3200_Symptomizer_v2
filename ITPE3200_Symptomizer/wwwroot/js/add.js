function addPatient() {

    var checkBoxes = $(".form-check-input");
    var checkedSymptoms = [];
    for (let i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].checked) {
            checkedSymptoms.push(checkBoxes[i].value);
        }
    }
           
    //---- Our database of diseases ----------//
    const flu = ["Fever or chills", "Cough", "Sore throat", "High temperature", "Muscle or body aches"]
    const covid_19 = ["Fever or chills", "Cough", "Sore throat","High temperature","Shortness of breath or difficulty breathing", "Muscle or body aches"]
    let foundDisease = findDisease(checkedSymptoms, flu, covid_19);

    function findDisease(checkedSymptoms, flu, covid_19) {
        var str1 = checkedSymptoms.sort().toString();
        var str2 = flu.sort().toString();
        var str3 = covid_19.sort().toString();
        if (str1.toLowerCase() === str2.toLowerCase()) {
            return "Flu";
        } else if (str1.toLowerCase() === str3.toLowerCase()) {
            return "COVID-19";
        } else {
            return "Common cold";
        }
    }

    const patient = {
        firstname: $("#firstname").val(),
        lastname: $("#lastname").val(),
        symptoms: checkedSymptoms.toString(),
        disease: foundDisease
    }
    console.log(patient)
    console.log(typeof(patient))!= 'undefine'
    $.post("Patient/AddPatient", patient, function () {        
            window.location.href = 'index.html';
    }).fail(function (status) {
        if (status.status === 404) {
            $("#fail").html("Oops.. Something wrong! Try again later!").css('color', 'red');
        }
    });
};



