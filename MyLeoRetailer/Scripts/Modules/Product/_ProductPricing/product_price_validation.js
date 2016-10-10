
$(function () { 

    $("#frmProductColor").validate({
        rules: {
            "Filter.Color": { required: true, ColorCodeExist: true },

            "ProductMRP.Vendor_Color_Code": { required: true },
        },
        messages: {

            "Filter.Color": { required: "Colour Code is required." },

            "ProductMRP.Vendor_Color_Code": { required: "Vendor Colour Code Required" },
        }
    });

    jQuery.validator.addMethod("ColorCodeExist", function (value, element) {

        var result = true;
        var Arr = [];

        $(".block").find("a").each(function () {
            Arr.push($(this).text());
        });

        if ($.inArray(value, Arr) > -1)
            result = false;
        else
            result = true;

        return result;

    }, "Colour Already Exists in List.");

});

