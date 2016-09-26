
//$(function ()
//{
//	$("#frmColor").validate({
//		rules: {
//		    "Color.Colour": { required: true },

//            //"Color.Colour_Code":{required: true},
//		},
//		messages: {

//		    "Color.Colour": { required: "Color is required." },

//            //"Color.Colour_Code": { required: "Color Code is required." }
//		}
//	});
//});

$(document).ready(function () {

	$("#frmColor").validate({
		rules: {
		    "Color.Colour": { required: true },

            "Color.Color_Code":{required: true},
            "Color.Colour": { required: true, validate_Colour: true },
		},
		messages: {

            "Color.Colour": { required: "Color is required." }
        }
    });

    jQuery.validator.addMethod("validate_Colour", function (value, element) {
        var result = true;

        if ($("#txtColour_Name").val() != "" && $("#hdnColour_Name").val() != $("#txtColour_Name").val()) {
            $.ajax({
                url: '/colour/check-colour-name',
                data: { color_Name: $("#txtColour_Name").val() },
                method: 'Post',
                async: false,
                success: function (data) {
                    if (data == true) {
                        result = false;
                    }
		}
	});
        }
        return result;

    }, "Colour is already exists.");

});