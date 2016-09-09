
$(function () {

    $("#btnSaveVendorContact").click(function () {
        if ($("#frmVendorContact").valid()) {
            alert(("#hdnVendorContact_Id"));
            if ($("#hdnVendorContact_Id").val() == 0) {
                $("#frmVendorContact").attr("action", "/VendorContact/Insert_Vendor_Contact/");
            }
            else {
                $("#frmVendorContact").attr("action", "/VendorContact/Update_Vendor_Contact/");
            }
            $('#frmVendorContact').attr("method", "POST");
            $('#frmVendorContact').submit();
        }
    });

});