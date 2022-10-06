function addSymptom(){
    let listofSymptoms = []
    const symptom = {
        symptomName: $("#symptom").val()
    }
    listofSymptoms.push(symptom)
    $("#allsymptoms").html(listofSymptoms)
    window.location.href="/"
}

function addPatient() {
    
    const patient = {
        name: $("#name").val(),
        lastname: $("#lastname").val(),
        age: $("#age").val(),
        
    }
    
    const url = "Patient/AddPatient";
    $.post(url, patient, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#fail").html("Fail in Database. Try again later.");
        }
    });
};