//Commented By Vinod Mane on 26/09/2016
//$(function () {
//    $("#frmSubCategory").validate({
//        rules: {
//            "SubCategory.Sub_Category": { required: true },
//        },
//        messages: {

//            "SubCategory.Sub_Category": { required: "Sub Category is required." }
//        }
//    });
//});
//End

//Added By Vinod Mane on 26/09/2016
$(document).ready(function () {

    $("#frmSubCategory").validate({
        rules: {
            "SubCategory.Sub_Category": { required: true },

            "SubCategory.Sub_Category_Code": { required: true },
            "SubCategory.Sub_Category": { required: true, validate_Sub_Category: true },
        },
        messages: {

            "SubCategory.Sub_Category": { required: "Sub Category is required." },

            "SubCategory.Sub_Category_Code": { required: "Sub Category Code is required." }
        }
    });

    jQuery.validator.addMethod("validate_Sub_Category", function (value, element) {
        var result = true;

        if ($("#txtSub_Category").val() != "" && $("#hdnSub_Category").val() != $("#txtSub_Category").val()) {
            $.ajax({
                url: '/sub-category/check-sub-category-name',
                data: { sub_category_Name: $("#txtSub_Category").val() },
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

    }, "Sub Category is already exists.");

});
//End