

$(document).ready(function () {

    //Added by vinod mane on 20/10/2016
    if ($("#hdn_EmployeeId").val() != 0) {

        // $("#btnCancel").attr('disabled', true);     


        if ($('[name="Employee.Is_Online"]').val() == "True") {
            $("#txtUser_Name").attr('disabled', true);
            $("#txtPassword").hide();
            $("#txtConfirmPassword").hide();
            $("#drpRole").attr('disabled', true);
        } else {

            $("#txtUser_Name").attr('enabled', true);
            $("#txtPassword").show();
            $("#txtConfirmPassword").show();
            $("#drpRole").attr('enabled', true);
        }

    }
    //End

});

$(function () {
 
    //addition by swapnali | Date:19/09/2016
    // $("#Employee_Home_Lindline").mask("(999) 999-9999");
    $("input.mask_phone_no").mask('(999) 9999-9999');
    $("input.mask_mobile_no").mask('(99) 99999-99999');
    //alert($('[name="Employee.IsActive"]').val());

    if ($('[name = "Employee.Employee_Id"]').val() == 0 || $('[name="Employee.Employee_Id"]').val() == " ") {
        $('[name="Employee.IsActive"]').val("true");
    }


    $('[name = "Employee.IsActive"]').change(function () {
        if ($('[name="Employee.IsActive"]').val() == "true") {
            $('[name="Employee.IsActive"]').val(1);
        }
        //else {
        //    $('[name="Employee.IsActive"]').val(0);
        //}
    });
    //$('[name="Employee.IsActive"]').val('True');
    //End

    $("#btnEmployeeSave").click(function ()
	{
        if ($('[name="Employee.Is_Online"]').val() == 1){
            $('[name="Employee.Is_Online"]').val('True');
        }

    
        //Modifiction
        if ($('[name="Employee.IsActive"]').val() == 1 || $('[name="Employee.IsActive"]').val() == "true" || $('[name="Employee.IsActive"]').val() == "True") {
            $('[name="Employee.IsActive"]').val(true);
        }
        else {
            $('[name="Employee.IsActive"]').val(false);
        }
       //// alert($('[name="Employee.IsActive"]').val());
       // //End

        if ($("#hdn_EmployeeId").val() != 0)
        {
            $("#txtPassword").rules("remove", "pwdcheck");
            $('#txtPassword').rules("remove");
            $('#txtConfirmPassword').rules("remove");
           
        }

        if ($("#frmEmployee").valid()) {
            if ($("#hdn_EmployeeId").val() == 0) {
               $("#frmEmployee").attr("action", "/Employee/Insert_Employee/");
            }
            else {
                $("#txtUser_Name").attr('disabled', false);
                $('#drpRole').attr("disabled", false);
                $("#frmEmployee").attr("action", "/Employee/Update_Employee/");
            }
            $('#frmEmployee').attr("method", "POST");
            $('#frmEmployee').submit();
        }
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

            //changes done by Sushant in txtPassword on 26th Oct 2016

            $('#txtUser_Name').rules("add", { required: true, validate_username: true, messages: { required: "User name is required." } });
            $('#txtPassword').rules("add", { required: true, pwdcheck: true, minlength: 6, messages: { required: "Password is required.", pwdcheck: "Please enter atleast one Uppercase, Lowercase, Special character and Number", minlength: "Please enter a value greater than or equal to {6}." } });
            $('#txtConfirmPassword').rules("add", { match_password: true });
            $('#drpRole').rules("add", { required: true, messages: { required: "Role is required." } });

        }

    });

    if ($('[name = "Employee.Is_Online"]').val() == "True" || $('[name = "Employee.Is_Online"]').val() == 1) {

        //changes done by Sushant in txtPassword on 26th Oct 2016

        $('#txtUser_Name').rules("add", { required: true, validate_username: true, messages: { required: "User name is required." } });
        $('#txtPassword').rules("add", { required: true, pwdcheck: true, minlength: 6, messages: { required: "Password is required.", pwdcheck: "Please enter atleast one Uppercase, Lowercase, Special character and Number", minlength: "Please enter a value greater than or equal to {6}." } });
        $('#txtConfirmPassword').rules("add", { match_password: true });
        $('#drpRole').rules("add", { required: true, messages: { required: "Role is required." } });
    }




});