
$(function () {

    $("#btnSaveVendorContact").click(function () {
        if ($("#frmVendorContact").valid()) {
          //  alert(("#hdnVendorContact_Id")); Change By Vinod Mane on 19/09/2016
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