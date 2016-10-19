
$(document).ready(function () {

    //Added by vinod mane on 13/10/2016
    //if ($("#hdnVendorContact_Id").val() != 0) {

    //    $("#btnCancel").attr('disabled', true);

    //}
    //End

});

$(function () {


    if ($("#hdnVendorContact_Id").val() == 0) {
        $("[name='VendorContact.IsActive']").val(1);
        document.getElementById('Flag').checked = true;
    }
    
    $("input.mask_mobile_no").mask('(99) 99999-99999');

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