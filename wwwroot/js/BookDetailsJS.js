$(document).ready(function(){

    $("#submitReview").click(function(){
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
        $.post("/Book/AddReview", { "Review": output }, function() {
            alert("Submitted BROOOO");
        }).fail(function(){
            alert("your review sucks");
        });
    });


});