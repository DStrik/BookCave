$(document).ready(function () {
    var bookId = $("#bookIdStorage").attr("data-bookId");

    $("#submitReview").click(function () {
        var review = $("#reviewText").val();
        var rating = Number($("#userRating").attr("data-rate-value"));

        console.log(review + bookId + rating);
        var output = {
            "BookId": bookId,
            "Rating": rating,
            "Review": review
        }

        console.log(output);
        $.post("/Book/AddReview", { "Review": output }, function () {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-bottom-full-width",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": 300,
                "hideDuration": 1000,
                "timeOut": 5000,
                "extendedTimeOut": 1000,
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr["success"]("Your review has successfully been added!");
        }).fail(function () {
            alert("your review sucks");
        });
    });


    $("#setFavorite").click(function () {
        $.post("/Book/SetFavoriteBook", { "id": bookId }, function () {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-full-width",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": 300,
                "hideDuration": 1000,
                "timeOut": 5000,
                "extendedTimeOut": 1000,
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr["success"]("This book has been set as your favorite book!", "Book added to favorite");
        }).fail(function () {
            Command: toastr["error"]("This book has been set as your favorite book!", "Book added to favorite");
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-full-width",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": 300,
                "hideDuration": 1000,
                "timeOut": 5000,
                "extendedTimeOut": 1000,
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
        });
    });

    $(".add-to-cart").click(function(){
        var id = $(this).data("id");
        $.post("/Cart/AddToCart/" + id, function(data, status){
          Command: toastr["success"]("Click here to view your cart", "Book has been added to cart!")
          toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "showDuration": 300,
            "hideDuration": 1000,
            "timeOut": 5000,
            "extendedTimeOut": 1000,
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
          }
        }).fail(function(){
          Command: toastr["error"]("Please try again later", "Book was not added to cart")
          toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "showDuration": 300,
            "hideDuration": 1000,
            "timeOut": 5000,
            "extendedTimeOut": 1000,
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
          }
        });
      });


});
