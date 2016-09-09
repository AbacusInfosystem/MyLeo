
$(function ()
{
    $("#frmEmployee").validate({
		rules: {
		    "Employee.Employee_Name": {
		        required: true
		    },

		    "Employee.Employee_Pincode": {
		        
		        digits: true
		    },
            		   
		    "Employee.Employee_Mobile1": {		        
		        digits: true
		    },

		    "Employee.Employee_EmailId": {
		        email: true
		    },

            
		},
		messages: {

		    "Employee.Employee_Name": {                
		        required: "Employee Name is required."
		    },
            
		    "Employee.Employee_Pincode": {
		        digits: "Enter only Digits"
		    },
            		    
		    "Employee.Employee_Mobile1": {
		        digits: "Enter only Digits"
		    },

		    "Employee.Employee_EmailId": {
		        email: "Invalid Email"
		    },


		}
    });


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