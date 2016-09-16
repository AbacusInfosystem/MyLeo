$(function () {

   
    $("#btnGiftVoucherSave").click(function () {
        if ($("#frmGiftVoucher").valid()) {
            //alert(("#hdnVendorContact_Id"));
            if ($("#hdn_GiftVoucherId").val() == 0) {
                $("#frmGiftVoucher").attr("action", "/GiftVoucher/Insert_Gift_Voucher/");
            }
            else {
                $("#frmGiftVoucher").attr("action", "/GiftVoucher/Update_Gift_Voucher/");
            }
            $('#frmGiftVoucher').attr("method", "POST");
            $('#frmGiftVoucher').submit();
        }
    });


    $("#btnGiftVoucherPrint").click(function () {       
        $("#frmGiftVoucher").attr("action", "/GiftVoucher/Print");
        $("#frmGiftVoucher").submit();           
    });

    if ($('#hdn_GiftVoucherId').val() != "") {        
        if ($('#mode').val() == 2) {
           
            $("#divBankName").show();
            $("#divCreditCardNo").show();
        } else {
            $("#divBankName").hide();
            $("#divCreditCardNo").hide();
        }
    }
       
    $("#mode").change(function () {        
        if ($(this).val() == 2) {
            $("#divBankName").show();
            $("#divCreditCardNo").show();
        } else {
            $("#divBankName").hide();
            $("#divCreditCardNo").hide();
        }
    });
});