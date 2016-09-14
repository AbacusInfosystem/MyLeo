
$(function ()
{
 
    $("#btnEmployeeSave").click(function ()
	{
        if ($('[name="Employee.Is_Online"]').val() == 1){
            $('[name="Employee.Is_Online"]').val('True');
        }
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
	 
    $("#chkSwitch").find('span').click(function () {
        $('[name="Employee.Is_Online"]').trigger("change");
    });

    $('[name = "Employee.Is_Online"]').change(function () {
      
        if ($(this).val() == 1 || $(this).val() == "true") {
         
            $(".online-field").hide("");

            $("#txtUser_Name").val("");
            $("#txtPassword").val("");
            $("#txtConfirmPassword").val("");
            $('#drpRole').val("");

            $("#txtUser_Name").rules("remove");
            $("#txtPassword").rules("remove");
            $("#txtConfirmPassword").rules("remove");
            $('#drpRole').rules("remove");
        }
        else {
          
            $(".online-field").show();

            $('#txtUser_Name').rules("add", { required: true, validate_username: true, messages: { required: "User name is required." } });
            $('#txtPassword').rules("add", { required: true, messages: { required: "Password is required." } });
            $('#txtConfirmPassword').rules("add", { match_password: true });
            $('#drpRole').rules("add", { required: true, messages: { required: "Role is required." } });

        }
        
    });
    
    if($('[name = "Employee.Is_Online"]').val() == "True" || $('[name = "Employee.Is_Online"]').val() == 1)
    {
        
        $('#txtUser_Name').rules("add", { required: true, validate_username: true, messages: { required: "User name is required." } });
        $('#txtPassword').rules("add", { required: true, messages: { required: "Password is required." } });
        $('#txtConfirmPassword').rules("add", { match_password: true });
        $('#drpRole').rules("add", { required: true, messages: { required: "Role is required." } });
    }
    

});