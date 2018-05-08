$(document).ready(function(){
    console.log("1");
    $(".incrementQty").click( function() {
        var counter = $('#qty').val();
        console.log("hey");
        counter++ ;
        $('#qty').val(counter);
        
        
    });
    $(".decrementQty").click( function() {
        var counter = $('#qty').val();
        if(counter > 1){
        counter-- ;
        $('#qty').val(counter);
        }

    });
    $('#gaur').click(function(){
        console.log("hallo");
    });
});