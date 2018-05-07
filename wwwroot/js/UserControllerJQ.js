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

    $("#changeShippingBilling").click(function (e) { 
        e.preventDefault();
        $.get("GetShippingBillingInformation", function (data, status) {
            console.log(data);
            console.log("Success");
            $("#editShippingBilling").modal("show");
        }).fail(function (err) {
            console.log(err);
            console.log(data);
            console.log("FailureAF");
            $("#editShippingBilling").modal("show");
        });
    });
});

