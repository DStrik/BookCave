// Material Select Initialization
// Initialize select list
$(document).ready(function () {
  $('.mdb-select').material_select();
  getAllAuthors();
  getAllGenres();
  getAllPublishers();

  if  ($("#typeAudioBook").is(":checked")){
    toggleAudioAndOthers("audiobook");
  } else {
    toggleAudioAndOthers("other");
  }
});


// Refresh list on click
// Get all information into select boxes
$("#refreshAuthors").click(function () {
  getAllAuthors();
});
$("#refreshGenres").click(function () {
  getAllGenres();
})
$('#refreshPublishers').click(function () {
  getAllPublishers();
})

function getAllAuthors() {
  getSelectList("GetAllAuthors", "#authorList", "Author(s)");
}

function getAllGenres() {
  getSelectList("GetAllGenres", "#genreList", "Genre(s)");
}

function getAllPublishers() {
  getSelectList("GetAllPublishers", "#publisherList", "Publisher");
}

// Get get select list from "Controller" Action, put into the Select list, and insert "field name" into the disabled box.
function getSelectList(callAction, selectList, fieldName) {
  $.get(callAction, function (data, status) {
    $(selectList).material_select('destroy');
    $(selectList).empty();
    $(selectList).append('<option value="" disabled selected>Select ' + fieldName + '...</option>');
    $.each(data, function (i, j) {
      $(selectList).append('<option value="' + j.id + '">' + j.name + '</option>');
    })
    $(selectList).append('<button type="button" class="btn-save btn btn-primary btn-sm">Save</button>');
    $(selectList).material_select();
  }).fail(function (err) {
    alert("Error has occured! Selection field for " + fieldName + " could not be obtained!");
  });
}


$("#typeSelector input").click(function (e) {
  if ($(this).val() == "Audio Book") {
    toggleAudioAndOthers("audiobook");
  } else {
    toggleAudioAndOthers("other");
  }
});

function toggleAudioAndOthers(setToType) {
  if (setToType == "audiobook") {
    $("#pageCount").prop("disabled", true);
    $("#audioLength").prop("disabled", false);
  } else {
    $("#audioLength").prop("disabled", true);
    $("#pageCount").prop("disabled", false);
  }
}