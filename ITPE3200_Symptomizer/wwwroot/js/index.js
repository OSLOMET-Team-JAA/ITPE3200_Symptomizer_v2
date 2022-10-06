$(function () {
    findAll();
});

function findAll() {
    $.get("patient/findAll", function (patients) {
        edit(patients);
    });
}

function edit(patients) {
    let out = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Name</th><th>Last name</th><th>Age</th><th>Symptoms</th>><th></th><th></th>" +
        "</tr>";
    for (let p of patients) {
        out += "<tr>" +
            "<td>" + p.name + "</td>" +
            "<td>" + p.lastname + "</td>" +
            "<td>" + p.age + "</td>" +
            "<td>" + p.symptoms + "</td>" +
            "<td> <a class='btn btn-primary' href='edit.html?id=" + p.id + "'>Edit</a></td>" +
            "<td> <button class='btn btn-danger' onclick='deleteCustomer(" + p.id + ")'>Delete</button></td>" +
            "</tr>";
    }
    out += "</table>";
    console.log(out),
        $("#patients").html(out);
}

function deleteCustomer(id) {
    const url = "Patient/DeletePatient?id=" + id;
    $.get(url, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#fail").html("Fail in Database. Try again later.");
        }

    });
}