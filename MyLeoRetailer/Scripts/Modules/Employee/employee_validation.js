
$(function ()
{
    $("#frmEmployee").validate({
		rules: {
		    "Employee.Employee_Name": {
		        required: true
		    },

		    //Addition by swapnali | Date:19/09/2016
		    "Employee.Employee_Gender": {
		        Employee_Gender: true
		    },
		    "Employee.Designation_Id": {
		        Designation: true
		    },
		    "Employee.Employee_Mobile2": {
		        // digits: true
		        number: true
		    },
		    "Employee.Employee_DOB": {
		        // digits: true
		        required: true
		    },
            //End

		    "Employee.Employee_Pincode": {
		        
		        // digits: true
		        number: true
		    },
            		   
		    "Employee.Employee_Mobile1": {		       
		        // digits: true
		        number: true
		    },

		    "Employee.Employee_EmailId": {
		        email: true
		    },

            
		},
		messages: {

		    "Employee.Employee_Name": {                
		        required: "Employee Name is required."
		    },
		    //Addition by swapnali | Date:19/09/2016
		    //"Employee.Employee_Gender": {
		    //    required: "Employee Gender is required."
		    //},
		    //"Employee.Designation_Id": {
		    //    required: "Employee Designation is required."
		    //},
            //End
            
            //Use Default Msg | Please enter a valid no.
		    //"Employee.Employee_Pincode": {
		    //    digits: "Enter only Digits"
		    //},
            		    
		    //"Employee.Employee_Mobile1": {
		    //    digits: "Enter only Digits"
		    //},

		    "Employee.Employee_DOB": {
		        required: "Employee DOB is required."
		    },
            //End
		    "Employee.Employee_EmailId": {
		        email: "Invalid Email"
		    },


		}
    });

    //Addition by swapnali | Date:19/09/2016
    jQuery.validator.addMethod("Employee_Gender", function (value, element) {
        var result = true;
        if (($(element).val()) == "0") {
            result = false;
        }

        return result;
    }, 'Employee Gender is required');

    jQuery.validator.addMethod("Designation", function (value, element) {
        var result = true;
        if (($(element).val()) == "0") {
            result = false;
        }

        return result;
    }, 'Employee Designation is required');
//End

    jQuery.validator.addMethod("validate_username", function (value, element) {
        var result = true;

        if ($("#txtUser_Name").val() != "" && $("#hdnUser_Name").val() != $("#txtUser_Name").val()) {
            $.ajax({
                url: '/employee/check-user-name',
                data: { user_Name: $("#txtUser_Name").val() },
                method: 'GET',
                async: false,
                success: function (data) {
                    if (data == true) {
                        result = false;
                    }
                }
            });
        }
        return result;

    }, "User name is already exists.");

    jQuery.validator.addMethod("match_password", function (value, element) {
        var result = true;

        if ($("#txtPassword").val() != $("#txtConfirmPassword").val()) {
            result = false;
        }
        return result;

    }, "Enter password same as above.");

});