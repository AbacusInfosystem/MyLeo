$(function () {
    

    $("#btnSaveVendorContact").click(function () {

        if ($("#frmVendorContact").valid()) {
            Save_Vendor_Contact();

        }

    });

});