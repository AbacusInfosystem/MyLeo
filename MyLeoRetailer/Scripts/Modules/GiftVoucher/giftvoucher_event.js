$(function () {

    
    $("#divBankName").hide();
    $("#divCreditCardNo").hide();

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

    if ( $('#hdn_GiftVoucherId').val() != 0) {
        $("#btnCancel").attr('disabled', true);//Added by vinod mane on 10/10/2016
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

            //Added by vinod mane on 28/09/2016
            $("#bankname").val("");
            $("#creditcardno").val("");
            //End
        } else {
            $("#divBankName").hide();
            $("#divCreditCardNo").hide();

            //Added by vinod mane on 28/09/2016
            $("#bankname").val("");
            $("#creditcardno").val("");
            //End
        }
    });

    //Added by vinod mane on 10/10/2016
    $("#btnPrint").click(function () {
        $('#Div_Print').printThis();
    });
   
    //End

    $("#btnCancel").click(function () {
      //  if ($("#frmGiftVoucher").valid()) {
          
            $("#divBankName").hide();
            $("#divCreditCardNo").hide();
       // }
    });
});