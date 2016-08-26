
$(function ()
{
	Get_Sub_Categories();

	$("#btnSaveSubCategory").click(function ()
	{
		Save_Sub_Category();
	});

	$(document).on("click", "[name='Sub_Category_List']", function ()
	{
		Get_Sub_Category_By_Id(this);
	});

	$("[name='Filter.Size_Name']").focusout(function ()
	{
		Get_Sub_Categories();
	});

});