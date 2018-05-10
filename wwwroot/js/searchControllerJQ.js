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

  $('#name-asc').on('click', function () {
    var nameAsc = $(".thecarditem").sort(function (a, b) {
        return $(a).find(".card-title").text() > $(b).find(".card-title").text();
    });
    $(".carditems-container").html(nameAsc);
  });

  $('#name-desc').on('click', function () {
    var nameDesc = $(".thecarditem").sort(function (a, b) {
        return $(a).find(".card-title").text() < $(b).find(".card-title").text();
    });
    $(".carditems-container").html(nameDesc);
  });

  $('#price-asc').on('click', function () {
    alert("works!");
    var priceAsc = $(".thecarditem").sort(function (a, b) {
        return Number($(a).find(".pricetag").text()) > Number($(b).find(".pricetag").text());
    });
    $(".carditems-container").html(priceAsc);
  });
  
  $('#price-desc').on('click', function () {
    var priceDesc = $(".thecarditem").sort(function (a, b) {
        return $(a).find(".pricetag").text() < $(b).find(".pricetag").text();
    });
    $(".carditems-container").html(priceDesc);
  });
});