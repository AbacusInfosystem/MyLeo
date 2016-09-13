

$(function ()
{
    InitializeAutoComplete($("#txtColor_Name"));

	Get_Colors();

	$("#btnSaveColor").click(function ()
	{
	    if ($("#frmColor").valid())
		{
			Save_Color();
		}
	});

	$(document).on("click", "[name='Color_List']", function ()
	{
		Get_Color_By_Id(this);

		//Get_SubColors(this);
	});

	$("[name='Filter.Color']").focusout(function ()
	{
		Get_Colors();
	});

	$(document).on("change", "#hdnColourId", function () {
	    Get_Colors();
	});

	$("#btnReset").click(function () {

	    ResetForm();

	}); 

});