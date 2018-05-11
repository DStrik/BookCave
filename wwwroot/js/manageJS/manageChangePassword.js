$(document).ready(function () {

    $("#submitEmployeeChangePassword").click(function (e) { 
        e.preventDefault();

        UpdatePassword();
    });

    $("#oldPassword").keypress(function (e) {
        if(e.which == 13)
        {
            UpdatePassword();
        }
    });

    $("#newPassword").keypress(function (e) {
        if(e.which == 13)
        {
            UpdatePassword();
        }
    });

    $("#confirmPassword").keypress(function (e) {
        if(e.which == 13)
        {
            UpdatePassword();
        }
    });

    function UpdatePassword() {
        $("#waitingModal").modal("show");
        
        var oldPassword = $("#oldPassword").val();
        var newPassword = $("#newPassword").val();
        var confirmPassword = $("#confirmPassword").val();

        var input = {
            "OldPassword" : oldPassword,
            "NewPassword" : newPassword,
            "ConfirmPassword" : confirmPassword
        };

        console.log(input);

        $.post("ChangePassword", input, function(data, status) {

            setTimeout(() => {

                $("#submitEmployeeChangePassword").closest("form").find("input[type=password], textarea").val("");
                $("#successModal").modal("show");
                $("#waitingModal").modal("hide");
            }, 500);
        }).fail(function(err) {
            setTimeout(() => {

                $("#errorModalChangePassword").modal("show");
                $("#waitingModal").modal("hide");
            }, 500);
        });
    };

    $("#cancel").click(function (e) {
        $(this).closest("form").find("input[type=password], textarea").val("");
    });

});