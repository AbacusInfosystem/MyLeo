

$(function () {
    $("#frmVendorContact").validate({
        rules: { 
            "VendorContact.Vendor_Id": { //Added by vinod mane on 21/09/2016
                VenderName: true
            },

            "VendorContact.First_Name": {
                required: true
            },

            "VendorContact.Last_Name": {
                required: true
            },

            "VendorContact.Pincode": {
                number: true,
                required:true
            },

            "VendorContact.Mobile1": {
                required:true,
                checkmobileno: true,
            },

            "VendorContact.Mobile2": {
                checkmobileno: true,
            },

            "VendorContact.Email_Id": {
                email: true
            }
        },
        messages: {

            //"VendorContact.Vendor_Id":{//Added by vinod mane on 21/09/2016
            //    required: "Select Vendor."
            //},
            "VendorContact.First_Name": {
                required: "First Name is required."
            },

            "VendorContact.Last_Name": {
                required: "Last Name is required."
            },

            "VendorContact.Pincode": {
                number: "Enter only digits"                
            },

            "VendorContact.Mobile1": {
                required: "Mobile number is required."
            },

            //"VendorContact.Mobile2": {
            //    digits: "Enter only digits"
            //},

            "VendorContact.Email_Id": {
                email: "Invalid Email"
            },
        }
    });

    jQuery.validator.addMethod("checkmobileno", function (value, element) {

        var result = true;
        var mobile1 = $("#txtMobile1").val();
        var mobile2 = $("#txtMobile2").val();

        if (mobile1 != "" && mobile1 != 0 && mobile2 != "" && mobile2 != 0) {

            if (mobile1 == mobile2) {
                result = false;
                //calculate(element);
            }
            else {
                result = true;
            }
        }
        return result;

    }, "You can not enter same mobile no.");

});


jQuery.validator.addMethod("VenderName", function (value, element) {
    var result = true;

    if ($("#drpVendor").val() == "0") {
        result = false;
    }

    return result;

}, "Vendor is Required.");
