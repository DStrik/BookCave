// Tooltips Initialization
$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})

// Steppers                
$(document).ready(function () {
    $('.mdb-select').material_select();
    var navListItems = $('div.setup-panel-2 div a'),
        allWells = $('.setup-content-2'),
        allNextBtn = $('.nextBtn-2'),
        allPrevBtn = $('.prevBtn-2'),
        lastNavStep = currNavStep = $('div.setup-panel-2 div a[href="#step-3"]');

    allWells.hide();

    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr('href')),
            $item = $(this);
            nextStep = $item.parent().next().children("a")

        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-amber').addClass('btn-success');
            $item.removeClass('btn-blue-grey').addClass('btn-amber');
            allWells.hide();
            $target.show();
            $target.find('input:eq(0)').focus();
        }

        if(lastNavStep.hasClass('disabled')){

            while(!nextStep.hasClass('disabled')){
                nextStep.addClass('disabled');
                nextStep.removeClass('btn-success').addClass('btn-blue-grey');
                nextStep = nextStep.parent().next.children;
            }
        }
    });

    allPrevBtn.click(function () {
        var curStep = $(this).closest(".setup-content-2"),
            curStepBtn = curStep.attr("id"),
            prevStepSteps = $('div.setup-panel-2 div a[href="#' + curStepBtn + '"]').parent().prev().children("a");
            currNavStep = $('div.setup-panel-2 div a[href="#' + curStepBtn + '"]');

        prevStepSteps.removeAttr('disabled').trigger('click');
    
    });

    allNextBtn.click(function () {

        var curStep = $(this).closest(".setup-content-2"),
            curStepBtn = curStep.attr("id"),
            nextStepSteps = $('div.setup-panel-2 div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='url']"),
            isValid = true;

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            }
        }

        if('form-group'.hasClass("has-error"))

        if (isValid){
        //verifies input in step on before going to next step
        //also fills in the input feild in step 2 as a read only
        if($(this).attr('id') == "verifyStep"){

            //$('#processingModal').modal('show');
            var bla = $("#checkOutForm").serialize();
            $.get('/CheckOut/Verify', bla, function(data, status) {

                $("#BillingFirstName1").val($("#BillingFirstName").val());
                $("#BillingLastName1").val($("#BillingLastName").val());
                $("#BillingStreetName1").val($("#BillingStreetName").val());
                $("#BillingHouseNumber1").val($("#BillingHouseNumber").val());
                $("#BillingCity1").val($("#BillingCity").val());
                $("#BillingZipCode1").val($("#BillingZipCode").val());
               // $("#BillingCountry1").val($('.BillingCountrySelect option:selected').val());
                $("#ShippingFirstName1").val($("#ShippingFirstName").val());
                $("#ShippingLastName1").val($("#ShippingLastName").val());
                $("#ShippingStreetName1").val($("#ShippingStreetName").val());
                $("#ShippingHouseNumber1").val($("#ShippingHouseNumber").val());
                $("#ShippingCity1").val($("#ShippingCity").val());
                $("#ShippingZipCode1").val($("#ShippingZipCode").val());
               // $("#ShippingCountry1").val($('.BillingCountrySelect option:selected').val());
                $("#FullName1").val($("#FullName").val());
                $("#CardNumber1").val($("#CardNumber").val());
                $("#ExpirationMonth1").val($("#ExpirationMonth").val());
                $("#ExpirationYear1").val($("#ExpirationYear").val());
                $("#Cvc1").val($("#Cvc").val());

                if (isValid){

                    nextStepSteps.removeClass('disabled').trigger('click');
                }

                $('#processingModal').modal('hide');

            }).fail(function(err) {
                $('#processingModal').modal('hide');
                alert("something wrong!")
            });
        };

        if($(this).attr('id') == "pay") {
            
            $('#pay').prop('disabled', true);
            var bla = $("#checkOutForm").serialize();
            $('#processingModal').modal('show');

            $.post('/CheckOut/Pay', bla, function(data, status) {
                $(".form-group").removeClass("has-error");
                console.log("bla")
                for (var i = 0; i < curInputs.length; i++) {
                    if (!curInputs[i].validity.valid) {
                        isValid = false;
                        $(curInputs[i]).closest(".form-group").addClass("has-error");
                    }
                }

                if (isValid){

                    nextStepSteps.removeClass('disabled').trigger('click');
                }

                $('#processingModal').modal('hide');
            }).fail(function(err) {
                $('#processingModal').modal('hide');
                alert("Error has occured!");
            });
        }
        }
    });


    $('div.setup-panel-2 div a.btn-amber').trigger('click');

    $.get('/CheckOut/GetCart', function(data, status) {
        var markupForTable = "";
            markupTotalPrice = "";
            totalprice = 0;
        $.each(data, function (i, j) {
            markupForTable += '<tr><td>' + j.title + '</td><td>' + j.quantity + '</td><td>' + j.price + '$</td><td>' + (j.quantity * j.price) + '$</td>';
            totalprice += (j.price * j.quantity);
        });
        markupTotalPrice += 'Total Amount: ' + totalprice.toFixed(2) + '$';
        $('#cartTable').html(markupForTable);
        $('#totalPrice').html(markupTotalPrice);
    }).fail(function (err) {
        alert("Error has occured!")
    });

    $.get("https://restcountries.eu/rest/v2", function (data, success) { 
        var markupCountry = '<option value="" disabled selected>Choose your country</option>';
        for(i = 0; i < data.length; i++) {
            markupCountry +='<option value="' + data[i].name + '">' + data[i].name + '</option>';
            console.log(data[i].name); 
        }
        $('#ShippingCountry').html(markupCountry).material_select();
        $('#BillingCountry').html(markupCountry).material_select();
        //$('.ShippingCountry-stuff').material_select();
        
        console.log(markupCountry);
    }).fail(function(err){
        alert("Error has occured");
    });
    

    // Changes the status of the input boxes in billing so that if checked
    // the input is disabled and information from shipping is copied to
    // billing in real time
    $("#checkbox1").change(function (e) { 
        e.preventDefault();

        if($("input.check-for-bill").is(":checked")) {
            $(".billing-information").prop("readonly", true);
            $("#BillingFirstName").val($("#ShippingFirstName").val());
            $("#BillingLastName").val($("#ShippingLastName").val());
            $("#BillingStreetName").val($("#ShippingStreetName").val());
            $("#BillingHouseNumber").val($("#ShippingHouseNumber").val());
            $("#BillingCity").val($("#ShippingCity").val());
            $("#BillingZipCode").val($("#ShippingZipCode").val());
            //$('.BillingCountrySelect option:selected').val($('.ShippingCountrySelect option:selected').val());
           // $('#BillingCountry').val($('.ShippingCountrySelect option:active selected').val());
            //$('#BillingCountry').val($('#ShippingCountry').val());
        }
    
        if(!$("input.check-for-bill").is(":checked")) {
            $(".billing-information").prop("readonly", false);
        }
    });

    $("#ShippingFirstName").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingFirstName").val($("#ShippingFirstName").val());
        }
    });

    $("#ShippingLastName").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingLastName").val($("#ShippingLastName").val());
        }
    });

    $("#ShippingStreetName").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingStreetName").val($("#ShippingStreetName").val());
        }
    });

    $("#ShippingHouseNumber").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingHouseNumber").val($("#ShippingHouseNumber").val());
        }
    });

    $("#ShippingHouseNumber").change(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingHouseNumber").val($("#ShippingHouseNumber").val());
        }
    });

    $("#ShippingCity").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingCity").val($("#ShippingCity").val());
        }
    });

    $("#ShippingZipCode").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingZipCode").val($("#ShippingZipCode").val());
        }
    });

    $("#ShippingCountry").keyup(function () {
        if($("input.check-for-bill").is(":checked")) {
            $("#BillingCountry").val($("#ShippingCountry").val());
        }
    });

    $("#submitShipBill").click(function (e) { 
        $("#processingModal").modal("show");
        $("#editShippingBilling").modal("hide");
    });
    var newCountry = $('.className option:selected').val();
});
