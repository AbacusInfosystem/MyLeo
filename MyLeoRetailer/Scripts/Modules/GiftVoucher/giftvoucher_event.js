$(function () {


    $("#btnGiftVoucherSave").click(function () {

        Save_Gift_Voucher();

        //if ($("#frmTax").valid()) {

    });

    $("#btnGiftVoucherPrint").click(function () {
       
        $("#frmGiftVoucher").attr("action", "/GiftVoucher/Print");
        $("#frmGiftVoucher").submit();
           
    });

    if ($('#hdn_GiftVoucherId').val() != "") {
        
        if ($('#mode').val() == 2) {
            $("#bankname").show();
            $("#creditcardno").show();
        } else {
            $("#bankname").hide();
            $("#creditcardno").hide();
        }

    }

   
    $("#mode").change(function () {
        
        if ($(this).val() == 2) {
            $("#bankname").show();
            $("#creditcardno").show();
        } else {
            $("#bankname").hide();
            $("#creditcardno").hide();
        }
    });


   

});