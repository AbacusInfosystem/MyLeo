$(document).ready(function () {


    $("#textQuantity_0").rules("add", { required: true, digits: true, messages: { required: "SKU Required", digits: "Invalid quantity." } });
    $("#textSKU_No_0").rules("add", { required: true, checkSKUExist: true, messages: { required: "Required field", } });


    $('#dtpReturn_Date').datepicker({

        dateFormat: "dd-mm-yy",
        changeMonth: true,
        changeYear: true,
        minDate: 0,
        autoclose: true,

    });

});


$(function () {


    $("[name='SalesReturn.Mobile']").focusout(function ()
    {
        Get_Customer_Name_By_Mobile_No();
    });


    $("#btnSaveSalesReturn").click(function ()
    {

        $("#tblSalesReturnItems").find("[id^='SalesReturnItemRow_']").each(function (i, row)
        {
            Add_Validation(i);
        });

        if ($("#frmSalesReturn").valid()) {

            if ($('#tblSalesReturnItems tbody tr').length > 0) {

                $("#frmSalesReturn").attr("action", "/SalesReturn/Insert_SalesReturn/");

                $('#frmSalesReturn').attr("method", "POST");

                $('#frmSalesReturn').submit();
            }
        }

    });


    $("#btnCustomer").click(function () {

        debugger;

        $("#hdnCreateCustomerFlag").val(true);

        alert($("#hdnCreateCustomerFlag").val());

        //$("#hdnInvoiceDate").val();

        //alert($("#hdnInvoiceDate").val());

        //$("#hdnMobileNo").val();

        //alert($("#hdnMobileNo").val());

        $('#txtReturn_No').removeClass("login-error");
        $('#txtReturn_No').rules("remove");

        $('#dtpReturn_Date').removeClass("login-error");
        $('#dtpReturn_Date').rules("remove");

        $('#txtMobileNo').removeClass("MobileNo error");
        $('#txtMobileNo').rules("remove");

        $('#txtCustomer_Name').removeClass("login-error");
        $('#txtCustomer_Name').rules("remove");

        $("#frmSalesReturn").attr("action", "/Customer/Index/");

        $('#frmSalesReturn').attr("method", "POST");

        $('#frmSalesReturn').submit();

    });


});

function CalculateTotal()
{

    var sumQuantity = 0;
    var sumGrossAmount = 0;

    var tr = $("#tblSalesReturnItems").find('[id^="SalesReturnItemRow_"]');


    if (tr.size() > 0)
    {
        for (var i = 0; i < tr.size() ; i++)
        {
            var Qty = parseFloat($("#tblSalesReturnItems").find('[id="textQuantity_' + i + '"]').val());
            var MRP = parseFloat($("#tblSalesReturnItems").find('[id="textMRP_Price_' + i + '"]').val());
            var Discount = parseFloat($("#tblSalesReturnItems").find('[id="textDiscount_Percentage_' + i + '"]').val());
            var DiscountAmt = (Discount == "" || Discount == undefined) ? 0 : parseFloat((Qty * MRP * Discount) / 100);
            $("#tblSalesReturnItems").find('[id="textSalesReturn_Discount_Amount_' + i + '"]').val(DiscountAmt);
            var Amount = parseFloat(MRP * Qty - DiscountAmt);
            $("#tblSalesReturnItems").find('[id="textAmount_' + i + '"]').val(Amount);
           
            sumQuantity = sumQuantity + Qty;
            sumGrossAmount = sumGrossAmount + Amount;
          
        }
    }

    $("#textTotalQuantity_0").val(sumQuantity);
    $("#textGrossAmount_0").val(sumGrossAmount.toFixed(2));
   
}


function CalculateCreditNoteAmt()
{

    var creditNoteAmt = 0;

    var CashPaidAmt = parseFloat($("#textTotalAmountReturnByCash_0").val());
    var sumGrossAmount = parseFloat($("#textGrossAmount_0").val());

    var creditNoteAmt = sumGrossAmount - CashPaidAmt;

    $("#textTotalAmountReturnByCreditNote_0").val(Math.round(creditNoteAmt));


}




//$("[name='SalesInvoice[0].SKU_Code']").focusout(function ()
//{
//    Get_Sales_Order_Items_By_SKU_Code();
//});

