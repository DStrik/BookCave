// Material Select Initialization
// Initialize select list
$(document).ready(function () {
  $('.mdb-select').material_select();
  getAllAuthors();
  getAllGenres();
  getAllPublishers();
});


// Refresh list on click
// Get all information into select boxes
$("#refreshAuthors").click(function () {
  getAllAuthors();
});
$("#refreshGenres").click(function() {
  getAllGenres();
})
$("#refreshPublishers").click(function() {
  getAllPublishers();
})

function getAllAuthors() {
  getSelectList("GetAllAuthors", "#authorList", "Author(s)")
}

function getAllGenres() {
  getSelectList("GetAllGenres", "#genreList", "Genre(s)");
}

function getAllPublishers() {
  getSelectList("GetAllPublishers", "#publisherList", "Publisher");
}

// Get get select list from "Controller", put into the Select list, and insert "field name" into the disabled box.
function getSelectList(callController, selectList, fieldName) {

  $.get(callController, function (data, status) {
    $(selectList).material_select('destroy');
    $(selectList).empty();
    $(selectList).append('<option value="" disabled selected>Select ' + fieldName + '...</option>');
    $.each(data, function (i, j) {
      $(selectList).append('<option value="' + j.id + '">' + j.name + '</option>');
    })
    $(selectList).material_select();
  }).fail(function (err) {
    alert("Error has occured!");
  });
}
