$(document).ready(function () {
    $('#testbtn').click(function () {
        $.ajax({
            method: "GET",
            url: "../Test/GetAllUser",
            data: { name: "John", location: "Boston" }
        }).done(function (msg) {
            alert("Data Saved: " + msg);
        });
    });
});