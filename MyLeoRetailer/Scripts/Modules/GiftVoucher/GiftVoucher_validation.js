

$(function () {
    $("#frmGiftVoucher").validate({
        rules: {
            "GiftVoucher.Gift_Voucher_No": { required: true },
            "GiftVoucher.Person_Name": { required: true }
            
        },
        messages: {

            "GiftVoucher.Gift_Voucher_No": { required: "Gift Voucher No is required." },
            "GiftVoucher.Person_Name": { required: "Person Name is required." }
            //"Branch.Far_Branch_Location_Pincode": { required: "Far Branch Pincode is required." }
        }
    });
});