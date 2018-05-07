// SideNav Button Initialization
$(".button-collapse").sideNav();

// Material Select Initialization
// Initialize select list
$(document).ready(function () {
  $('.mdb-select').material_select();
  getAllAuthors();
  getAllGenres();
  getAllPublishers();
});


// Refresh list on click
// Get all authors into dropdown in add book
$("#refresh-authors").click(function () {
  getAllAuthors();
});
$("#refresh-genres").click(function() {
  getAllGenres();
})
$("#refresh-publishers").click(function() {
  getAllPublishers();
})

// Get all Authors into dropdown
function getAllAuthors() {
  $.get("GetAllAuthors", function (data, status) {
    $("#author-list").material_select('destroy');
    $("#author-list").empty();
    $("#author-list").append('<option value="" disabled selected>Select Author(s)...</option>');
    $.each(data, function (i, j) {
      $("#author-list").append('<option value="' + j.id + '">' + j.name + '</option>');
    })
    $("#author-list").material_select();
  }).fail(function (err) {
    alert("Error has occured!");
  });
}

// Get all Genres into dropdown
function getAllGenres() {
  $.get("GetAllGenres", function (data, status) {
    $("#genre-list").material_select('destroy');
    $("#genre-list").empty();
    $("#genre-list").append('<option value="" disabled selected>Select Genre(s)...</option>');
    $.each(data, function (i, j) {
      $("#genre-list").append('<option value="' + j.id + '">' + j.name + '</option>');
    })
    $("#genre-list").material_select();
  }).fail(function (err) {
    alert("Error has occured!");
  });
}

// Get all Genres 
function getAllPublishers() {
  $.get("GetAllPublishers", function (data, status) {
    $("#publisher-list").material_select('destroy');
    $("#publisher-list").empty();
    $("#publisher-list").append('<option value="" disabled selected>Select Publisher...</option>');
    $.each(data, function (i, j) {
      $("#publisher-list").append('<option value="' + j.id + '">' + j.name + '</option>');
    })
    $("#publisher-list").material_select();
  }).fail(function (err) {
    alert("Error has occured!");
  });
}
