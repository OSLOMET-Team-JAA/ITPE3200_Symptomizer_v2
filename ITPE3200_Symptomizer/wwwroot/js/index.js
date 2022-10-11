$(function () {
    findAll();
});

function findAll() {
    $.get("Patient/FindAll", function (patients) {
        console.log(patients)
        edit(patients);
    }).fail(function (status) {
        if (status.status === 404) {
            $("#fail").html("Oops.. Something wrong! Try again later!").css('color', 'red');
        }
    })
}

function edit(patients) {
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
    console.log(out),
        $("#patients").html(out);
}
function deletePatient(id) {
    const url = "Patient/deletePatient?id=" + id;
    $.get(url, function () {
        window.location.href = "index.html";
    })
}
    