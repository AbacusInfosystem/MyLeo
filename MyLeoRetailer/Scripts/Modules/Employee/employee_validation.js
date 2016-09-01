
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
});