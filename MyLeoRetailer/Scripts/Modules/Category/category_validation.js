
$(function ()
{
	$("#frmCategory").validate({
		rules: {
			"Category.Category": { required: true },
		},
		messages: {

			"Category.Category": { required: "Category is required." }
		}
	});
});