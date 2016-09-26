
$(function ()
{
	$("#frmCategory").validate({
		rules: {
			"Category.Category": { required: true }, 
 
			"Category.Category_Code": { required: true },
		},
	 
		messages: {

		    "Category.Category": { required: "Category is required." },

            "Category.Category_Code": { required: "Category Code is required." }
		}
	});
});