
$(function ()
{
	$("#frmColor").validate({
		rules: {
		    "Color.Colour": { required: true },

            "Color.Color_Code":{required: true},
		},
		messages: {

		    "Color.Color": { required: "Color is required." },

		    "Color.Color_Code": { required: "Color Code is required." },
		}
	});
});