$('#incrementQty').click( function() {
    var counter = $('#qty').val();
    counter++ ;
    $('#qty').val(counter);
});
$('#decrementQty').click( function() {
    var counter = $('#qty').val();
    if(counter > 1){
    counter-- ;
    $('#qty').val(counter);
    }

});
