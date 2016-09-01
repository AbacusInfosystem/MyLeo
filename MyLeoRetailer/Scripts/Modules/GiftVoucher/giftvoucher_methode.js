

function Save_Gift_Voucher() {

    var gvViewModel =
		{
		    GiftVoucher: {

		        Gift_Voucher_Id: $("[name='GiftVoucher.Gift_Voucher_Id']").val(),

		        Gift_Voucher_No: $("[name='GiftVoucher.Gift_Voucher_No']").val(),

		        Person_Name: $("[name='GiftVoucher.Person_Name']").val(),

		        Gift_Voucher_Date: $("[name='GiftVoucher.Gift_Voucher_Date']").val(),

		        Gift_Voucher_Expiry_Date: $("[name='GiftVoucher.Gift_Voucher_Expiry_Date']").val(),

		        Gift_Voucher_Amount: $("[name='GiftVoucher.Gift_Voucher_Amount']").val(),

		        Payment_Mode: $("[name='GiftVoucher.Payment_Mode']").val(),

		        Bank_Name: $("[name='GiftVoucher.Bank_Name']").val(),

		        Credit_Card_No: $("[name='GiftVoucher.Credit_Card_No']").val(),

		        IsActive: $("[name='GiftVoucher.IsActive']").val(),
		    }
		}

    var url = "";
    if ($("#frmGiftVoucher").valid()) {

        if ($("[name='GiftVoucher.Gift_Voucher_Id']").val() == "" || $("[name='GiftVoucher.Gift_Voucher_Id']").val() == 0) {

            url = "/GiftVoucher/Insert_Gift_Voucher";
        }
        else {
            url = "/GiftVoucher/Update_Gift_Voucher";
        }
    }
    $.ajax({

        url: url,

        data: JSON.stringify(gvViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
            var obj = $.parseJSON(response);

            Reset_Gift_Voucher();

            Friendly_Messages(obj);

        }
    });


}

function Reset_Gift_Voucher() {

    $("[name='GiftVoucher.Gift_Voucher_Id']").val("");

    $("[name='GiftVoucher.Gift_Voucher_No']").val("");

    $("[name='GiftVoucher.Person_Name']").val("");

    $("[name='GiftVoucher.Gift_Voucher_Date']").val("");

    $("[name='GiftVoucher.Gift_Voucher_Expiry_Date']").val("");

    $("[name='GiftVoucher.Gift_Voucher_Amount']").val("");

    $("[name='GiftVoucher.Payment_Mode']").val("");

    $("[name='GiftVoucher.Bank_Name']").val("");

    $("[name='GiftVoucher.Credit_Card_No']").val("");

    $("[name='GiftVoucher.IsActive']").val("");

   
}
