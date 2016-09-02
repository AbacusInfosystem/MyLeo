$(function () {
    $("#frmBranch").validate({
        rules: {
            "Branch.Branch_Name": {
                required: true
            },

            "Branch.Branch_Landline1": {
                digits: true
            },

            "Branch.Branch_Landline2": {
                digits: true
            },

            "Branch.Branch_Pincode": {
                digits: true
            },
            
        },
        messages: {

            "Branch.Branch_Name": {
                required: "Branch Name is required."
            },

            "Branch.Branch_Landline1": {
                digits: "Enter only digits"
            },

            "Branch.Branch_Landline2": {
                digits: "Enter only digits"
            },
            
            "Branch.Branch_Pincode": {
                digits: "Enter only digits"
            },

          
        }
    });
});