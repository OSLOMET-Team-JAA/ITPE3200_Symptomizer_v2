function loggOut() {
    $.get("Patient/LoggOut", function () {
        window.location.href = 'loggIn.html';
    });
}

