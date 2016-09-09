
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
            }
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
            }
        }
    });
});