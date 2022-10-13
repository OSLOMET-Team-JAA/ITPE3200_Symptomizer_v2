$(function () {
    findAll(); //--Getting data during page loading
});

function findAll() {
    $.get("Patient/FindAll", function (patients) {
        addDataTable(patients);
    }).fail(function (status) {
        if (status.status === 404) {
            $("#fail").html("Oops.. Something wrong! Try again later!").css('color', 'red');
        }
    })
}

//----- Showing our Patients' data -------------------------------//
function addDataTable(patients) {
    let out = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>First Name</th><th>Last name</th><th>Symptoms</th><th>Disease</th><th></th><th></th>" +
        "</tr>";
    for (let p of patients) {        
        out += "<tr>" +
            "<td>" + p.firstname + "</td>" +
            "<td>" + p.lastname + "</td>" +
            "<td>" + p.symptoms + "</td>" +
            "<td>" + p.disease + "</td>" +
            "<td> <a class='btn btn-primary' href='edit.html?id=" + p.id + "'>Edit</a></td>" +
            "<td> <button class='btn btn-danger' onclick='deletePatient(" + p.id + ")'>Delete</button></td>" +
            "</tr>";
    }
    out += "</table>";
        $("#patients").html(out);
}

//---------- Function to delete Patient by ID ----------//
function deletePatient(id) {
    const url = "Patient/deletePatient?id=" + id;
    $.get(url, function () {
        window.location.href = "index.html";
    })
}
    