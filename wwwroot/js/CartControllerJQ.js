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
    $("#update").click(function(){
        Update();
        var qtys = [];
        $(".price").each(function() {
            var input = $(this).parent().parent().next().find("input").val();
            qtys.push(input);
        });
        var cartItemIds = [];
        $(".cartItem").each(function(){
            var id = $(this).text();
            cartItemIds.push(id);
        });

        $.post("/Cart/ChangeQuantity", {"qtys": qtys, "cartItemIds": cartItemIds}, function(data, status){
        });
    });
    $(".removeBtn").click(function(){
        var deletionRow = $(this).closest("tr");
        var id = Number($(this).parent().next().find("p").text());
        $.post("/Cart/RemoveItem", {"cartItemId": id}, function(data, status){
            deletionRow.fadeOut(function() {
                $(this).remove();
                getTotal();
            });   
        });
    });
    $("#clearAll").click(function(){
        var cartItems = [];
        $(".cartItem").each(function(){
            var id = $(this).text();
            cartItems.push(id);
        });
        $.post("/Cart/ClearCart", {"cartItems": cartItems}, function(data, status){
            $(".price").each(function(){
                var deletionRow = $(this).closest("tr");
                deletionRow.slideUp(function(){
                    $(this).remove();
                    getTotal();
                })
            })
        });
    });
    Update();
});
