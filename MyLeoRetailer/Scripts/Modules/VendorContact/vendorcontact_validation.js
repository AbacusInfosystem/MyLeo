

$(function () {
    $("#frmCVendorContactPrimaryInfo").validate({
        rules: {
            "VendorContact.First_Name": { required: true },

            "VendorContact.Last_Name": { required: true }
        },
        messages: {

            "VendorContact.First_Name": { required: "First Name is required." },

            "VendorContact.Last_Name": { required: "Last Name is required." }
        }
    });
});


