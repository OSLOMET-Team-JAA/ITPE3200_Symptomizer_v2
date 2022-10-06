$(function () {

    const id = window.location.search.substring(1);
    const url = "Patient/FindOne?" + id;
    $.get(url, function (Patient) {
        $("#id").val(Patient.id);
        $("#name").val(Patient.name);
        $("#lastname").val(Patient.lastname);
        $("#age").val(Patient.address);
        $("#symptoms").val(Patient.postnumber);
    });
});

function editPatient() {
    const patient = {
        id: $("#id").val(),
        name: $("#name").val(),
        lastname: $("#lastname").val(),
        age: $("#age").val(),
        symptoms: $("#symptoms").val()
    };
    $.post("Patient/EditPatient", patient, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#fail").html("Fail in Database. Try again later.");
        }
    });
}