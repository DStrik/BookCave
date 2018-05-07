$(document).ready(function () {

    $("#ViewFavBook").click(function (e) { 
        e.preventDefault();

        $.get("FavoriteBook", function(data, status){
            console.log("status: " + status);
            console.log(data);
        }).fail(function(err) {
            console.log("Error man");
        })

        $("#modalFavoriteBook").modal("show");
    });

});