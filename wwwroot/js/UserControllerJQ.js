$(document).ready(function () {
    console.log("UsercontrollerJavascript up and running");

    $("#changePassword").click(function (e) { 
        e.preventDefault();
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
            $("#modalChangePassword").modal("hide");

            var oldPassword = $("#oldPassword").val("");
            var newPassword = $("#newPassword").val("");
            var confirmPassword = $("#confirmPassword").val("");
        }).fail(function (err) {
            $("#ModalWarning").modal("show");
        });
    });

    // Gets the users favorite book
    $("#ViewFavBook").click(function (e) { 
        e.preventDefault();
        $("#errorImage").hide();
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
                         + '<div class="text-center"><button type="button" class="btn btn-outline-info btn-rounded waves-effect'
                         + ' mt-0 mb-3 p-2 pl-3 pr-3">Go to book details page</button></div>';

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
        console.log("CLICKED!!!!");
        $.get("GetShippingBillingInformation", function (data, status) {
            console.log("My data: " + data);

            if(data)
            {
                $("#ShippingFirstName").val(data.shippingfirstname);
                $("#ShippingLastName").val(data.shippinglastname);
                $("#ShippingStreetName").val(data.shippingstreetname);
                $("#ShippingHouseNumber").val(data.shippinghousenumber);
                $("#ShippingCity").val(data.shippingcity);
                $("#ShippingZipCode").val(data.shippingzipcode);
                $("#ShippingCountry").val(data.shippingcountry);

                $("#BillingFirstName").val(data.billingfirstname);
                $("#BillingLastName").val(data.billinglastname);
                $("#BillingStreetName").val(data.billingstreetname);
                $("#BillingHouseNumber").val(data.billinghousenumber);
                $("#BillingCity").val(data.billingcity);
                $("#BillingZipCode").val(data.billingzipcode);
                $("#BillingCountry").val(data.billingcountry);
            }
            
            $("#editShippingBilling").modal("show");
        }).fail(function () {
            console.log("IN FAIL FUNCTION");
            $("#editShippingBilling").modal("show");
        });
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

    /*$("#submitShipBill").click(function (e) { 
        e.preventDefault();
        $("#areYouSure").modal("show");
    }); */

    // End of Modal controller
});

