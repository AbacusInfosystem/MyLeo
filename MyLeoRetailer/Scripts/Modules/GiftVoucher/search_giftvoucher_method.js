
function Get_Gift_Vouchers() {
    var gvViewModel =
		{
		    Filter: {

		        Gift_Voucher_No: $("[name='Filter.Gift_Voucher_No']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divGiftVoucherPager"))
		    }
		}

    $.ajax({

        url: "/GiftVoucher/Get_Gift_Vouchers",

        data: JSON.stringify(gvViewModel),// data we are sending to server

        dataType: 'json',  //WHAT WE ARE EXPECTING

        type: 'POST',

        contentType: 'application/json', //WHAT WE ARE SENDING

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Gift_Voucher_List");

            $("#divGiftVoucherPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}

function Get_Gift_Voucher_By_Id(obj) {

    $("[name='Gift_Voucher_List']").removeClass("active");

    $(obj).addClass("active");

    $("[name='GiftVoucher.Gift_Voucher_No']").val($(obj).text());

    $("[name='GiftVoucher.Person_Name']").val($(obj).text());

    $("[name='GiftVoucher.Gift_Voucher_Date']").val($(obj).text());

    $("[name='GiftVoucher.Gift_Voucher_Expiry_Date']").val($(obj).text());

    $("[name='GiftVoucher.Gift_Voucher_Amount']").val($(obj).text());

    $("[name='GiftVoucher.Payment_Mode']").val($(obj).text());

    $("[name='GiftVoucher.Bank_Name']").val($(obj).text());

    $("[name='GiftVoucher.Credit_Card_No']").val($(obj).text());

    $("[name='GiftVoucher.Gift_Voucher_Id']").val($(obj).attr("data-identity"));

    $("#hdn_GiftVoucherId").val($(obj).attr("data-identity"));
}