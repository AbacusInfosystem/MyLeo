﻿

$(function () {

    Get_Gift_Vouchers();

    $("[name='Filter.Gift_Voucher_No']").focusout(function () {
        Get_Gift_Vouchers();
    });


    $(document).on("click", "[name='Gift_Voucher_List']", function () {
        Get_Gift_Voucher_By_Id(this);
    });

    $("#btnGiftVoucher").click(function () {
        $("#frmGiftVoucher").attr("action", "/GiftVoucher/Get_Gift_Voucher_By_Id");
        $("#frmGiftVoucher").submit();
    });

    $(document).on('change', '[name="Gift_Voucher_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdn_GiftVoucherId").val(this.value);
            //$("#btnGiftVoucher").show();
            //$("#btncreateGV").hide();

            document.getElementById("btnGiftVoucher").disabled = false;
        }
    });


    $("#btncreateGV").click(function () {

        $("#frmGiftVoucher").attr("action", "/GiftVoucher/Index");
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

    $('#drpTransaction').trigger('change');

    //Added By Vinod Mane on 22/09/2016
    $(document).on("change", "#hdnGift_Voucher_No", function () {
        Get_Gift_Vouchers();
    });
   
});
