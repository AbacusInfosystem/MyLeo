

$(function ()
{
 
    $("#btnEmployeeSave").click(function ()
	{
	    if ($("#frmEmployee").valid())
		{ 
	            if ($("#hdn_EmployeeId").val() == 0) {
	                $("#frmEmployee").attr("action", "/Employee/Insert_Employee/");
	            }
	            else {
	                $("#frmEmployee").attr("action", "/Employee/Update_Employee/");
	            }
	            $('#frmEmployee').attr("method", "POST");
	            $('#frmEmployee').submit();
		}
    });

    $("#btnReset").click(function () {

        ResetForm();

    });
	 
});