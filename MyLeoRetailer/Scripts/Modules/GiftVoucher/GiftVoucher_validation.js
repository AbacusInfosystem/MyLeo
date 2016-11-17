
$(function () {
    $("#frmGiftVoucher").validate({
        rules: {
            "GiftVoucher.Gift_Voucher_No": {
                required: true,
                Validate_Gift_Voucher: true
            },

            "GiftVoucher.Person_Name": {
                required: true
            },

            "GiftVoucher.Gift_Voucher_Amount": {
                digits: true,
                required: true
            },
            //Added by vinod mane on 28/09/2016
            "GiftVoucher.Gift_Voucher_Date": {
                required: true,
                chkdate:true
            },
            "GiftVoucher.Gift_Voucher_Expiry_Date": {
                required: true,
                chkdate:true
            }
            //end
        },
        messages: {

            "GiftVoucher.Gift_Voucher_No": {
                required: "Gift Voucher No is required."
            },

            "GiftVoucher.Person_Name": {
                required: "Person Name is required."
            },

            "GiftVoucher.Gift_Voucher_Amount": {
                digits: "Enter only Digits",
                required:"Amount is required."
            },

            //Added by vinod mane on 28/09/2016
            "GiftVoucher.Gift_Voucher_Date": {
                required: "Voucher date is required."
            },

            "GiftVoucher.Gift_Voucher_Expiry_Date": {
                required: "Voucher expiry date is required."
            }
            //End


        }
    });

    $.validator.addMethod('chkdate', function (value) {

        var result = true;

        var VoucherExpiryDate = $("#txtVoucherExpiryDate").val();
        var VoucherDate = $("#txtVoucherDate").val();

        if (VoucherExpiryDate != "" && VoucherDate != "") {

            if (VoucherExpiryDate > VoucherDate) {
                result = true;
               
            }
            else {

                result = false;
               
            }
        }
       

        return result;


    }, 'Please Select valid date');

    jQuery.validator.addMethod("Validate_Gift_Voucher", function (value, element) {
        var result = true;

        if ($("#txtGiftVoucherNo").val() != "" && $("#hdn_GiftVoucherNo").val() != $("#txtGiftVoucherNo").val()) {
            $.ajax({
                url: '/GiftVoucher/check-gift-voucher-no',
                data: { Gift_Voucher_No: $("#txtGiftVoucherNo").val() },
                method: 'GET',
                async: false,
                success: function (data) {
                    if (data == true) {
                        result = false;
                    }
                }
            });
        }
        return result;

    }, "Gift voucher no is already exists.");

});