$(document).ready(function () {
    console.log("UsercontrollerJavascript up and running");
    //$("#profilePic").attr("src","input image here");
    // Changes the password for the user
    
    $("#togglePasswordModal").click(function (e) { 
        e.preventDefault();
        $("#oldPassword").val("");
        $("#newPassword").val("");
        $("#confirmPassword").val("");
        $("#modalChangePassword").modal("show");
    });

    $("#changePassword").click(function (e) { 
        e.preventDefault();

        $("#processingModal").modal("show");
        $("#modalChangePassword").modal("hide");

        var oldPassword = $("#oldPassword").val();
        var newPassword = $("#newPassword").val();
        var confirmPassword = $("#confirmPassword").val();
        var inp = {
            "oldPassword" : oldPassword,
            "newPassword" : newPassword,
            "confirmPassword" : confirmPassword
        };

        $.post("ChangePassword", inp, function (data, status) {

            $("#centralModalSuccess").modal("show");
            $("#processingModal").modal("hide");

            var oldPassword = $("#oldPassword").val("");
            var newPassword = $("#newPassword").val("");
            var confirmPassword = $("#confirmPassword").val("");
        }).fail(function (err) {
            setTimeout(function() {
                $("#ModalWarning").modal("show");
                $("#processingModal").modal("hide");
            }, 500);
        });
    });

    // Gets the users favorite book

    // Change shipping and billing modal controller
    $("#changeShippingBilling").click(function (e) { 
        e.preventDefault();

        $("#editShippingBilling").modal("show");
    });

    // Function for closing the modal
    $("#BillShipClose").click(function (e) { 
        e.preventDefault();
        $("#editShippingBilling").modal("hide")
    });

    // Changes the status of the input boxes in billing so that if checked
    // the input is disabled and information from shipping is copied to
    // billing in real time
    $("#checkbox1").change(function (e) { 
        e.preventDefault();

        if($("input.check-for-bill").is(":checked")) {
            $(".billing-information").prop("readonly", true);
            $("#BillingFirstName").val($("#ShippingFirstName").val());
            $("#BillingLastName").val($("#ShippingLastName").val());
            $("#BillingStreetName").val($("#ShippingStreetName").val());
            $("#BillingHouseNumber").val($("#ShippingHouseNumber").val());
            $("#BillingCity").val($("#ShippingCity").val());
            $("#BillingZipCode").val($("#ShippingZipCode").val());
            $("#BillingCountry").val($("#ShippingCountry").val());
        }
    
        if(!$("input.check-for-bill").is(":checked")) {
            $(".billing-information").prop("readonly", false);
        }
    });

    $("#ShippingFirstName").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingFirstName").val($("#ShippingFirstName").val());
        }
    });

    $("#ShippingLastName").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingLastName").val($("#ShippingLastName").val());
        }
    });

    $("#ShippingStreetName").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingStreetName").val($("#ShippingStreetName").val());
        }
    });

    $("#ShippingHouseNumber").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingHouseNumber").val($("#ShippingHouseNumber").val());
        }
    });

    $("#ShippingHouseNumber").change(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingHouseNumber").val($("#ShippingHouseNumber").val());
        }
    });

    $("#ShippingCity").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingCity").val($("#ShippingCity").val());
        }
    });

    $("#ShippingZipCode").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingZipCode").val($("#ShippingZipCode").val());
        }
    });

    $("#ShippingCountry").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingCountry").val($("#ShippingCountry").val());
        }
    });

    $("#submitShipBill").click(function (e) { 
        $("#processingModal").modal("show");
        $("#editShippingBilling").modal("hide");
    });

    // End of Modal controller

    // Upload Image
    $("#EditImage").click(function (e) { 
        e.preventDefault();
        $("#UploadImageModal").modal("show");
    });

    $("#submitImage").click(function (e) { 
        $("#processingModal").modal("show");
        $("#UploadImageModal").modal("hide");
    });
    // Upload Image

    //Change Profile Name
    $("#ChangeUserName").click(function (e) { 
        e.preventDefault();

        $("#UserName").hide();
        $("#ChangeNameInput").show();
        
    });

    $("#UserFirstNameInput").keypress(function (e) { 
        if(e.which == 13) {
            UpdateUserName();
        }
    });

    $("#UserLastNameInput").keypress(function (e) { 
        if(e.which == 13) {
            UpdateUserName();
        }
    });

    $("#AcceptNameChange").click(function (e) { 
        e.preventDefault();
        UpdateUserName();
    });

    $("#CancelNameChange").click(function (e) { 
        e.preventDefault();
        $("#ChangeNameInput").hide();
        $("#UserName").show();
    });

    function UpdateUserName() {
        
        $("#processingModal").modal("show");

        var newFirstName = $("#UserFirstNameInput").val();
        var newLastName = $("#UserLastNameInput").val();

        var inp = {
            "firstname" : newFirstName,
            "lastname" : newLastName
        }

        $.post("ChangeFirstLastName", inp, function (data, status) {

            $("#UserFirstNameInput").empty();
            $("#UserLastNameInput").empty();

            $("#ChangeNameInput").hide();
            $("#UserName").empty().text(newFirstName + " " + newLastName).show();
            $("#processingModal").modal("hide");
            
        }).fail(function (err) {

            setTimeout(function() {
                $("#ModalWarningUserName").modal("show");
                $("#processingModal").modal("hide");
            }, 500);
        });      
    }

    $("#SignupSubmit").click(function (e) {

        $("#processingModal").modal("show");
        var SignupForm = $("#SignupForm").serialize();
        
        $.post("SignUp", SignupForm, function(data, status) {
            document.location.href="/";
        }).fail(function (err) {
            setTimeout(function() {
                $("#ModalWarningSignUp").modal("show");
                $("#processingModal").modal("hide");
            }, 500);
        });
    });

    $("#LogInSubmit").click(function (e) {

        $("#processingModal").modal("show");
        var LoginForm = $("#LogInForm").serialize();
        
        $.post("Login", LoginForm, function(data, status) {
            document.location.href="/";
        }).fail(function (err) {
            setTimeout(function() {
                console.log("Status: " + status);
                console.log("Error: " + err);
                $("#ModalWarningLogin").modal("show");
                $("#processingModal").modal("hide");
            }, 500);
        });
    });
    $(".viewDetails").click(function (e) {
        var id = $(this).data("id");
        console.log(id);
        document.location.href="/User/OrderDetails/" + id;
    });
    $('#printer').click(function(){
        var divToPrint=document.getElementById('printMe');

          var newWin=window.open('','Print-Window');

        newWin.document.open();

        newWin.document.write('<html><body onload="window.print()">'+divToPrint.innerHTML+'</body></html>');

        newWin.document.close();

        setTimeout(function(){newWin.close();},10);
    });

});