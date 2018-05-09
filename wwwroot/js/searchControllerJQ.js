// Material Select Initialization
// Initialize select list
$(document).ready(function () {
  $('.mdb-select').material_select();
  getAllAuthors();
  getAllGenres();
  getAllPublishers();

  function getAllAuthors() {
    getSelectList("/Search/GetAllAuthors", "#authorList", "Author(s)")
  }

  function getAllGenres() {
    getSelectList("/Search/GetAllGenres", "#genreList", "Genre(s)");
  }

  function getAllPublishers() {
    getSelectList("/Search/GetAllPublishers", "#publisherList", "Publisher");
  }
  

  $(".add-to-cart").click(function(){
    var id = $(this).data("id");
    $.post("/Cart/AddToCart/" + id, function(data, status){
      Command: toastr["success"]("Click here to view your cart", "Book has been added to cart!")
      toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": true,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "showDuration": 300,
        "hideDuration": 1000,
        "timeOut": 5000,
        "extendedTimeOut": 1000,
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
      }
    }).fail(function(){
      Command: toastr["error"]("Please try again later", "Book was not added to cart")
      toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": true,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "showDuration": 300,
        "hideDuration": 1000,
        "timeOut": 5000,
        "extendedTimeOut": 1000,
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
      }
    });
  });
  
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

});