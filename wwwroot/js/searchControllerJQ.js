// Material Select Initialization
// Initialize select list
$(document).ready(function () {
  $('.mdb-select').material_select();
  getAllAuthors();
  getAllGenres();
  getAllPublishers();
});

function getAllAuthors() {
  getSelectList("search/GetAllAuthors", "#authorList", "Author(s)")
}

function getAllGenres() {
  getSelectList("search/GetAllGenres", "#genreList", "Genre(s)");
}

function getAllPublishers() {
  getSelectList("search/GetAllPublishers", "#publisherList", "Publisher");
}

// Get get select list from "Controller", put into the Select list, and insert "field name" into the disabled box.
function getSelectList(callAction, selectList, fieldName) {

  $.get(callAction, function (data, status) {
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
