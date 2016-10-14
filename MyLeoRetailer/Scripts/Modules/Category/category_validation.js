
//$(function ()
//{
//	$("#frmCategory").validate({
//		rules: {
//			"Category.Category": { required: true },
//		},
//		messages: {

//			"Category.Category": { required: "Category is required." }
//		}
//	});
//});

//Added by Vinod Mane on 26/09/2016
$(document).ready(function () {

    $("#frmCategory").validate({
        
		rules: {
		    "Category.Category": { required: true, validate_Category: true },
 
			"Category.Category_Code": { required: true },
          //  "Category.Category": { required: true, validate_Category: true },
		},
	 
		messages: {

		    "Category.Category": { required: "Category is required." },

            "Category.Category_Code": { required: "Category Code is required." }
		}
	});

    jQuery.validator.addMethod("validate_Category", function (value, element) {
        var result = true;

        if ($("#txtCategory").val() != "" && $("#hdnCategory_Name").val() != $("#txtCategory").val()) {
            $.ajax({
                url: '/category/check-category-name',
                data: { category_Name: $("#txtCategory").val() },
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

    }, "Category is already exists.");

});