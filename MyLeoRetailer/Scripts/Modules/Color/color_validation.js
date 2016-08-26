
$(function ()
{
	$("#frmColor").validate({
		rules: {
		    "Color.Colour": { required: true },

            //"Color.Colour_Code":{required: true},
		},
		messages: {

		    "Color.Colour": { required: "Color is required." },

            //"Color.Colour_Code": { required: "Color Code is required." }
		}
	});
});