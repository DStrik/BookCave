// Material Select Initialization
// Initialize select list
$(document).ready(function () {
  $('.mdb-select').material_select();
  getAllAuthors();
  getAllGenres();
  getAllPublishers();
});

function getAllAuthors() {
  getSelectList("/Search/GetAllAuthors", "#authorList", "Author(s)")
}

function getAllGenres() {
  getSelectList("/Search/GetAllGenres", "#genreList", "Genre(s)");
}

function getAllPublishers() {
  getSelectList("/Search/GetAllPublishers", "#publisherList", "Publisher");
}

// Get get select list from "Controller", put into the Select list, and insert "field name" into the disabled box.
function getSelectList(callAction, selectList, fieldName) {

  $.get(callAction, function (data, status) {
    $.each(data, function (i, j) {
      $(selectList).append('<option value="' + j.id + '">' + j.name + '</option>');
    })
    $(selectList).material_select();
  }).fail(function (err) {
    alert("Error has occured!");
  });
}
