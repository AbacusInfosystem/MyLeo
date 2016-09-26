//Commented By Vniod Mane on 26/09/2016

$(function () {
    $("#frmBrand").validate({
        rules: {
            "Brand.Brand_Name": {
                required: true
            },
            "Brand.Brand_Code": {
                required: true
            },
        },
        messages: {

            "Brand.Brand_Name": {
                required: "Brand is required."
            },
            "Brand.Brand_Code": {
                required: "Brand Code is required."
            }
        }
    });
});
//End

//Added By Vniod Mane on 26/09/2016
//$(document).ready(function () {

//    $("#frmBrand").validate({
//        rules: {
//            "Brand.Brand_Name": { required: true, validate_Brand: true },
//        },
//        messages: {

//            "Brand.Brand_Name": { required: "Brand is required." }
//        }
//    });

//    jQuery.validator.addMethod("validate_Brand", function (value, element) {
//        var result = true;

//        if ($("#txtBrand_Name").val() != "" && $("#hdnBrand_Name").val() != $("#txtBrand_Name").val()) {
//            $.ajax({
//                url: '/brand/check-brand-name',
//                data: { brand_Name: $("#txtBrand_Name").val() },
//                method: 'GET',
//                async: false,
//                success: function (data) {
//                    if (data == true) {
//                        result = false;
//                    }
//                }
//            });
//        }
//        return result;

//    }, "Brand is already exists.");

//});
//end
