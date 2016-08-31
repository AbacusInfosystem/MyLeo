
$(function ()
{
    $("#frmEmployee").validate({
		rules: {
		    "Employee.Employee_Name": { required: true },

		    "Employee.Employee_Gender": { required: true },

		    "Employee.Employee_DOB": { required: true },

		    //"Employee.Branch_Id": { required: true },

		   // "Employee.Designation_Id": { required: true },

		    "Employee.Employee_Address": { required: true },

		    "Employee.Employee_Pincode": { required: true, digits: true },

		    "Employee.Employee_Country": { required: true },

		    "Employee.Employee_State": { required: true },

		    "Employee.Employee_City": { required: true },

		    "Employee.Employee_Mobile1": { required: true, digits: true },

		    "Employee.Employee_EmailId": { required: true,email: true }, 
            
		},
		messages: {

		    "Employee.Employee_Name": { required: "Employee Name is required." },

		    "Employee.Employee_Gender": { required: "Gender is required." },

		    "Employee.Employee_DOB": { required: "Employee DOB is required." },

		    "Employee.Branch_Id": { required: "Branch is required." },

		    "Employee.Designation_Id": { required: "Designation is required." },

		    "Employee.Employee_Address": { required: "Employee Address is required." },

		    "Employee.Employee_Pincode": { required: "Pincode is required.", digits: "Enter Digits" },

		    "Employee.Employee_Country": { required: "Country is required." },

		    "Employee.Employee_State": { required: "State is required." },

		    "Employee.Employee_City": { required: "City is required." },

		    "Employee.Employee_Mobile1": { required: "Mobile No is required.", digits: "Enter Digits" },

		    "Employee.Employee_EmailId": { required: "EmailId is required.", email: "Invalid Email" },
		}
	});
});