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
$('#refreshPublisher').click(function () {
  getAllPublishers();
})

function getAllAuthors() {
  getSelectList("/Manage/GetAllAuthors", "#authorList", "Author(s)", "Author");
}

function getAllGenres() {
  getSelectList("/Manage/GetAllGenres", "#genreList", "Genre(s)", "Genre");
}

function getAllPublishers() {
  getSelectList("/Manage/GetAllPublishers", "#publisherList", "Publisher", "Publisher");
}


// Get get select list from "Controller" Action, put into the Select list, and insert "field name" into the disabled box.
function getSelectList(callAction, selectList, fieldName, idOfOld) {
  $.get(callAction, function (data, status) {
    $(selectList).material_select('destroy');
    var markup = "";
    markup += '<option value="" disabled selected>Select ' + fieldName + '...</option>';
    var arr = [];
    $("#old" + idOfOld + " span").each(function (index, elem) {
      arr.push(Number($(this).text()));
    });
    var oldList = "";
    $.each(data, function (i, j) {
      if ($.inArray(j.id, arr) !== -1) {
        oldList += '"' + j.name + '"'
        markup += '<option value="' + j.id + '" selected>' + j.name + '</option>';
      } else {
        markup += '<option value="' + j.id + '">' + j.name + '</option>';
      }
    });
    $("#old" + idOfOld + "List").text(oldList);
    markup += '<button type="button" class="btn-save btn btn-primary btn-sm">Save</button>';
    $(selectList).html(markup);
    $(selectList).material_select();
  }).fail(function (err) {
    alert("Error has occured! Selection field for " + fieldName + " could not be obtained!");
  });
}

$("#typeSelector input").click(function (e) {
  if ($(this).val() == "Audio Book") {
    toggleAudioAndOthers("audiobook");
  } else {
    toggleAudioAndOthers("others");
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