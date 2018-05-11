$(document).ready(function () {

    $("#cancel").click(function (e) {
        $(this).closest("form").find("input[type=text], textarea").val("");
        $(this).closest("form").find("input[type=password], textarea").val("");
        $(this).closest("form").find("input[type=email], textarea").val("");
    });

    $("#submit").click(function (e) {
        $("#waitingModal").modal("show");
    });

});