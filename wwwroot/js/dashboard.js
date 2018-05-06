// SideNav Button Initialization
$(".button-collapse").sideNav();

// Material Select Initialization
$(document).ready(function() {
    $('.mdb-select').material_select();
  });

$("#refresh-authors").click(function() {

  alert("goin in");

  $.get("RefreshAuthors", function(data, status){

    $.each(data, function(i, j) {
      $("#author-list").find('ul').append('<option value="' + j.id + '">' + j.name + '</option>');
      alert(j.id)
    })

  }).fail(function(err){
    alert("Error has occured!");
  });
});
