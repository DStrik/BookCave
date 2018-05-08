$(document).ready(function(){
    
    console.log("CartJS up and running");
    $(".incrementQty").click( function() {
        var counter = $(this).parent().find("input").val();
        counter++;
        $(this).parent().find('input').val(counter);
    });
    $(".decrementQty").click( function() {
        var counter = $(this).parent().find("input").val();
        if(counter > 1){
        counter--;
        }
        $(this).parent().find("input").val(counter);
    });

    function isInt(n) {
        return n % 1 === 0;
     }

     function getTotal(){
        var total = 0;
        var totalArray = $('.amount').map(function(){
            return $.trim($(this).text());
        }).get();

        $.each(totalArray, function(i, j) {
            total += Number(j);
        });
        if(!isInt(total)){
            total = total.toFixed(2);
            }
        $("#total").text(total.toString());
    }
    function Update(){
        $(".price").each(function() {
            var price = Number($(this).text());
            var input = $(this).parent().parent().next().find("input").val();
            var amount = price * input;
            if(!isInt(amount)){
                amount = amount.toFixed(2);
                }
            amount.toString();
            $(this).parent().parent().next().next().find("span").text(amount);
            getTotal();
        });
    }
    $("#update").click(Update);
    Update();
});
