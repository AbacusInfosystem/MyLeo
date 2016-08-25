

$(function ()
{
	Get_Categories();

	$("#btnSaveCategory").click(function ()
	{
		if ($("#frmCategory").valid())
		{
			Save_Category();
		}
	});

	$(document).on("click", "[name='Category_List']", function ()
	{
		Get_Category_By_Id(this);

		Get_SubCategories(this);
	});

	$("[name='Filter.Category']").focusout(function ()
	{
		Get_Categories();
	});


});