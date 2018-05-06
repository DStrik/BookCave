// SideNav Button Initialization
$(".button-collapse").sideNav();

// Material Select Initialization
$(document).ready(function() {
    $('.mdb-select').material_select();
  });

$.get("Manage/GetAuthorList", function(data, status){
  for(var i = 0; i < data.authorlist.size; i++) {
    $("#author-list").append('<option value="' + data.authorlist[i].Id + '">' + data.authorlist[i].Name + '</option');
  }
});
