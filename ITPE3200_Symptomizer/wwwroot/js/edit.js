$(function () {
    const id = window.location.search.substring(1);
    const url = "Patient/FindPatient?" + id
    $.get(url, function (patients) {
        $("#id").val(patients.id);
        $("#firstname").val(patients.firstname);
        $("#lastname").val(patients.lastname);
        
        //-------- Checkboxs' property "checked" recovery ----------//
        const allSymptoms = []; //that list required to hold a string and further splitting
        allSymptoms.push(patients.symptoms);
        let symptomsList = allSymptoms[0].split(',') //now we got new array with splitted symptoms
        console.log(symptomsList)

        //-------- Loop through to find which checkbox to be checked ----------//
        for (let i = 0; i < symptomsList.length; i++) {
            if (symptomsList[i] != null) {
                const checkBoxes = $(".form-check-input");
                for (let j = 0; j<checkBoxes.length; j++) {
                    if (checkBoxes[j].value == symptomsList[i]) {
                        checkBoxes[j].checked = true;                        
                    }
                }                                    
            }                
        }
    });
});

function editPatient() {
    var checkBoxes = $(".form-check-input");
    var checkedSymptoms = [];
    for (let i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].checked) {
            checkedSymptoms.push(checkBoxes[i].value);
        }
    }

    //---- Our database of diseases ----------//
    const flu = ["Fever or chills", "Cough", "Sore throat","High temperature" ,"Muscle or body aches"]
    const covid_19 = ["Fever or chills", "Cough", "Sore throat", "High temperature", "Shortness of breath or difficulty breathing", "Muscle or body aches"]
    let foundDisease = findDisease(checkedSymptoms,flu,covid_19);
        
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
        id: $("#id").val(),
        firstname: $("#firstname").val(),
        lastname: $("#lastname").val(),
        symptoms: checkedSymptoms.toString(),
        disease: foundDisease
    }
    $.post("Patient/EditPatient", patient, function () {
        window.location.href = 'index.html';
    }).fail(function (status) {
        if (status.status === 404) {
            $("#fail").html("Oops.. Something wrong! Try again later!").css('color', 'red');
        }
    });
};
