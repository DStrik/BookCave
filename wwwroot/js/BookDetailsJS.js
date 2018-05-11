$(document).ready(function () {

    $("#submitReview").click(function () {
        var review = $("#reviewText").val();
        var bookId = Number($(this).attr("data-bookId"));
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
        $.post("/Book/SetFavoriteBook", function () {
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
            alert("not set as favorite");
        });
    });
});
