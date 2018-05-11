// SideNav Button Initialization
$('.button-collapse').sideNav();

$("#addPublisher").click(function() {
    var serialized = $("#addPublisherForm").serialize();
    $.post("/Manage/AddPublisher", serialized, function(data, status){
        alert('hi');
        window.top.close();
    }).fail(function() {
        alert("There was an error when attempting to add new publisher, please try again another time");
    });
});

$("#addAuthor").click(function() {
    var serialized = $("#addAuthorForm").serialize();
    $.post("/Manage/AddAuthor", serialized, function(data, status){
        window.top.close();
    }).fail(function() {
        alert("There was an error when attempting to add new publisher, please try again another time");
    });
});

$("#addGenre").click(function() {
    var serialized = $("#addGenreForm").serialize();
    $.post("/Manage/AddGenre", serialized, function(data, status){
        window.top.close();
    }).fail(function() {
        alert("There was an error when attempting to add new publisher, please try again another time");
    });
});
