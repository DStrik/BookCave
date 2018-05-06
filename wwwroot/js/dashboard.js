// SideNav Button Initialization
$(".button-collapse").sideNav();

// Material Select Initialization
$(document).ready(function() {
    $('.mdb-select').material_select();
  });


function checkBoxCollapse(checkboxId, collapseDivId) {

  if ($("#" + checkboxId).is(":checked")) {
    $("#" + collapseDivId).slideDown();
  } else {
    $("#" + collapseDivId).slideUp();
  }

}

// Make Paperback collapse
$("#showPaperback").click( function() {
  checkBoxCollapse("includePaperback", "paperback");
});

// Make Hardcover collapse 
$("#showHardcover").click( function() {
  checkBoxCollapse("includeHardcover", "hardcover");
});

// Make e-book collapse
$("#showEbook").click( function() {
  checkBoxCollapse("includeEbook", "ebook");
});

// Make audio book collapse 
$("#showAudioBook").click( function() {
  checkBoxCollapse("includeAudioBook", "audioBook");
});