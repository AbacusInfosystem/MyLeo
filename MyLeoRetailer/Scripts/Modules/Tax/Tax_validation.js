//$(function () {
//    $("#frmTax").validate({
//        rules: {
//            "Tax.Tax_Name": {
//                required: true
//            },

//            "Tax.Tax_Value": {
//                number: true
//            },
//        },
//        messages: {

//            "Tax.Tax_Name": {
//                required: "Tax Name is required."
//            },

//            "Tax.Tax_Value": {
//                digits: "Enter Only Digits"
//            },
//        }
//    });
//});


$(document).ready(function () {

    $("#frmTax").validate({
        rules: {
            "Tax.Tax_Name": { required: true, validate_Tax: true },
            "Tax.Tax_Value": { required: true, number: true, positiveNumber: true },
        },
        messages: {

            "Tax.Tax_Name": { required: "Tax Name is required." },
          
            "Tax.Tax_Value": { required: "Tax value is required" ,number: "Enter Only Digits" },

        }
    });

    jQuery.validator.addMethod("validate_Tax", function (value, element) {
        var result = true;

        if ($("#txt_Tax_Name").val() != "" && $("#hdnTaxName").val() != $("#txt_Tax_Name").val()) {
            $.ajax({
                url: '/Tax/check-tax-name',
                data: { Tax_name: $("#txt_Tax_Name").val() },
                method: 'GET',
                async: false,
                success: function (data) {
                    if (data == true) {
                        result = false;
                    }
                }
            });
        }
        return result;

    }, "Tax Name is already exists.");

    jQuery.validator.addMethod('positiveNumber',
    function (value) {// /^-?\d{2}(\.\d+)?$/
        var match = (/^\-?[0-9]*\.?[0-9]+$/).exec(value);
        //alert(match);
        var result = false;
        if (match[0] > 0)
            return true;
    }, 'Enter a positive and greater than 0 number.');

});