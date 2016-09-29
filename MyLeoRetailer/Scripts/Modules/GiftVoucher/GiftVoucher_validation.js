
$(function () {
    $("#frmGiftVoucher").validate({
        rules: {
            "GiftVoucher.Gift_Voucher_No": {
                required: true
            },

            "GiftVoucher.Person_Name": {
                required: true
            },

            "GiftVoucher.Gift_Voucher_Amount": {
                digits: true
            },
            //Added by vinod mane on 28/09/2016
            "GiftVoucher.Gift_Voucher_Date": {
                required: true
            },
            "GiftVoucher.Gift_Voucher_Expiry_Date": {
                required: true
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
                digits: "Enter only Digits"
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
});