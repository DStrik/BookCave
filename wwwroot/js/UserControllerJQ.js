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
    $("#ViewFavBook").click(function (e) { 
        e.preventDefault();
        $("#errorImage").hide();
        $(".un-center").addClass("text-center");
        var loading = '<div class="preloader-wrapper big active m-5 loading-thing">'
                      + '<div class="spinner-layer spinner-blue-only">'
                      + '<div class="circle-clipper left">'
                      + '<div class="circle"></div>'
                      + '</div>'
                      + '<div class="gap-patch">'
                      + '<div class="circle"></div>'
                      + '</div>'
                      + '<div class="circle-clipper right">'
                      + '<div class="circle"></div>'
                      + '</div>'
                      + '</div>'
                      + '</div>';

        $("#FavoriteBookInfo").html(loading);
        $("#FavoriteBookImg").append(loading);
        $("#modalFavoriteBook").modal("show");

        // Gets the book from the database and puts it in a markup to return as Json
        // The image is taken in as a byte array and then converted to a jpg
        $.get("FavoriteBook", function(data, status){
            console.log("status: " + status);
            var content = '<img class="img-fluid mt-5 ml-3" src="data:image/jpg;base64,' + data.coverImage + '">';
            //var content = '<a href="/book/details/' + data.bookId + '" <img class="img-fluid" src="data:image/jpg;base64,' + data.coverImage + '"></a>';
            $("#FavoriteBookImg").html(content);

            var authorMarkup = "";
            for(var i = 0; i < (data.author.length - 1); i++) {
                authorMarkup += data.author[i].name;
                authorMarkup += ", ";
            }
            authorMarkup += data.author[data.author.length - 1].name;

            var genreMarkup = "";
            for(var i = 0; i < (data.genre.length - 1); i++) {
                genreMarkup += data.genre[i].name;
                genreMarkup += ", ";
            }
            genreMarkup += data.genre[data.genre.length - 1].name;

            var markup = '<h1 class="mt-1 text-center">' + data.title + '</h1><hr><br><p><strong>Author/s</strong>: ' 
                         + authorMarkup + '<br><strong>Genre: </strong>' + genreMarkup + '<br><strong>ISBN: </strong>'
                         + data.isbn + '<br><strong>Type: </strong>' + data.type + '<br><strong>Publishing Year: </strong>'
                         + data.publishingYear + '</p><br><h3 class="text-right mr-3"><strong>Price: </strong>' + data.price + '$</h3>'
                         + '<div class="text-center"><a type="button" href="/book/details/' + data.bookId + '" class="btn btn-outline-info btn-rounded waves-effect'
                         + ' mt-0 mb-3 p-2 pl-3 pr-3">Go to book details page</a></div>';
            $(".un-center").removeClass("text-center");
            $("#FavoriteBookInfo").html(markup);

            console.log(data);
            // Error handling for the user if the book isn't receivable
        }).fail(function(err) {
            
            $(".loading-thing").hide();
            $("#errorImage").show();
            $("#FavoriteBookInfo").html("<br><br><br><br><p>There was an error in retrieving your book</p><p>Please try again later...</p>");
            
        });
    });

    
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
            $('#BillingCountry').prop('disabled', true);
            $('#BillingCountry').html($('#ShippingCountry')).material_select();

        }
    
        if(!$("input.check-for-bill").is(":checked")) {
            $(".billing-information").prop("readonly", false);
            $('#BillingCountry').removeAttr('disabled');
            $.get("https://restcountries.eu/rest/v2", function (data, success) { 
                var markupCountry = '';
                for(i = 0; i < data.length; i++) {
                    markupCountry +='<option value="' + data[i].name + '">' + data[i].name + '</option>'; 
                }
                $('#BillingCountry').append(markupCountry)
                $('#BillingCountry').material_select();
                //$('.ShippingCountry-stuff').material_select();
                
            }).fail(function(err){
                alert("Error has occured");
            });
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

    $("#ShippingCountry").change(function () {
        if($("input.check-for-bill").is(":checked")) {
            $('#BillingCountry').prop('disabled', true);
            $('#BillingCountry').html($('#ShippingCountry')).material_select();
            $('#BillingCountry').val($('#ShippingCountry').val());
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
            $("#VerySpecificIdBecauseThisIsOnAllPages").html(newFirstName + " " + newLastName);
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
        e.preventDefault();
        $("#errorImage").hide();
        $(".un-center").addClass("text-center");
        var loading = '<div class="preloader-wrapper big active m-5 loading-thing">'
                      + '<div class="spinner-layer spinner-blue-only">'
                      + '<div class="circle-clipper left">'
                      + '<div class="circle"></div>'
                      + '</div>'
                      + '<div class="gap-patch">'
                      + '<div class="circle"></div>'
                      + '</div>'
                      + '<div class="circle-clipper right">'
                      + '<div class="circle"></div>'
                      + '</div>'
                      + '</div>'
                      + '</div>';
                      
        $("#ViewDetailsModal").modal("show");

        $.get("/User/OrderDetails/" + id , function(data, status){
            document.location.href="/User/OrderDetails/" + id;
            $('#printer').click(function(){
                var divToPrint=document.getElementById('printMe');
    
                var newWin=window.open('','Print-Window');
    
                newWin.document.open();
    
                newWin.document.write('<html><body onload="window.print()">'+divToPrint.innerHTML+'</body></html>');
    
                newWin.document.close();
    
                setTimeout(function(){newWin.close();},10);
            }); 
        }).fail(function(err) {
            $(".loading-thing").hide();
            $("#errorImage").show();
            $("#FavoriteBookInfo").html("<br><br><p class='pt-4'><strong>Fuck</strong></p>");
        });
    });

//This is for country list

    $.get("https://restcountries.eu/rest/v2", function (data, success) { 
        var markupCountry = '';
        for(i = 0; i < data.length; i++) {
            markupCountry +='<option value="' + data[i].name + '">' + data[i].name + '</option>'; 
        }
        $('#ShippingCountry').append(markupCountry)
        $('#BillingCountry').append(markupCountry)
        $('#ShippingCountry').material_select();
        $('#BillingCountry').material_select();
        //$('.ShippingCountry-stuff').material_select();
        
    }).fail(function(err){
        alert("Error has occured");
    });

});
