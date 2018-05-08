$(document).ready(function(){
    console.log("CartJS up and running");
    $(".incrementQty").click( function() {
        var counter = $(this).parent().find("input").val();
        counter++ ;
        $(this).parent().find("input").val(counter);
        var amount = Number($(this).parent().next().find("span").text());
        amount /= counter - 1;
        amount *= counter;
        if(!isInt(amount)){
            amount = amount.toFixed(2);
        }
        amount.toString();
        $(this).parent().next().find("span").text(amount);

        
    });
    $(".decrementQty").click( function() {
        var counter = $(this).parent().find("input").val();
        if(counter > 1){
        counter--;
        $(this).parent().find("input").val(counter);
        var amount = Number($(this).parent().next().find("span").text());
        var minus = amount / (counter + 1);
        amount -= minus;
        if(!isInt(amount)){
        amount = amount.toFixed(2);
        }
        amount.toString();
        $(this).parent().next().find("span").text(amount);
        }
    });
    $(".qty").change(function(){
        var counter = $(this).val();
        var price = Number($(this).parent().prev().find("span").text());
        console.log(counter);
        var amount = Number($(this).parent().next().find("span").text());
        amount = counter * price;
        if(!isInt(amount)){
            amount = amount.toFixed(2);
        }
        amount.toString();
        $(this).parent().next().find("span").text(amount);

    });
});
function isInt(n) {
    return n % 1 === 0;
 }