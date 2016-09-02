

$(function () {
    $("#frmVendorContact").validate({
        rules: {
            "VendorContact.First_Name": {
                required: true
            },

            "VendorContact.Last_Name": {
                required: true
            },

            "VendorContact.Pincode": {
                number: true,
            },

            "VendorContact.Mobile1": {
                number: true,
            },

            "VendorContact.Mobile2": {
                number: true,
            },

            "VendorContact.Email_Id": {
                email: true
            }
        },
        messages: {

            "VendorContact.First_Name": {
                required: "First Name is required."
            },

            "VendorContact.Last_Name": {
                required: "Last Name is required."
            },

            "VendorContact.Pincode": {
                digits: "Enter only digits"
            },

            "VendorContact.Mobile1": {
                digits: "Enter only digits"
            },

            "VendorContact.Mobile2": {
                digits: "Enter only digits"
            },

            "VendorContact.Email_Id": {
                email: "Invalid Email"
            },
        }
    });
});


