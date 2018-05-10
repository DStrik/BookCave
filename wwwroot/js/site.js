new WOW().init();

$(document).ready(function(){
    // Initiate star ratings
    var options = {
        max_value: 5,
        step_size: 0.5,
    }
    $(".rate").rate(options);

    alert('off!');
    $('.rate-off').off(function() {
        alert("off!");
    });
});