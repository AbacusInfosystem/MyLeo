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

       

        $("#hdnCreateCustomerFlag").val(true);

      

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
            //var Qty = parseFloat($("#tblSalesReturnItems").find('[id="textQuantity_' + i + '"]').val());
            //Added by vinod mane on 12/10/2016
            var Qty = $("#tblSalesReturnItems").find('[id="textQuantity_' + i + '"]').val();
            if (Qty == "" || Qty == "NaN") {
                Qty = 1;
                $('#textQuantity_' + i).val(1);
            }
            //End

            //var MRP = parseFloat($("#tblSalesReturnItems").find('[id="textMRP_Price_' + i + '"]').val());

            //Added by vinod mane on 12/10/2016
            var MRP = $("#tblSalesReturnItems").find('[id="textMRP_Price_' + i + '"]').val();
            if (MRP == "" || MRP == "NaN") {
                MRP = 0;
                $('#textMRP_Price_' + i).val(0);
            }
            //End
            //var Discount = parseFloat($("#tblSalesReturnItems").find('[id="textDiscount_Percentage_' + i + '"]').val());

            //Added by vinod mane on 12/10/2016
            var Discount = $("#tblSalesReturnItems").find('[id="textDiscount_Percentage_' + i + '"]').val();
            if (Discount == "" || Discount == "NaN") {
                Discount = 0;
                $('#textDiscount_Percentage_' + i).val(0);
            }
            //End

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

    // var CashPaidAmt = parseFloat($("#textTotalAmountReturnByCash_0").val());
    // var sumGrossAmount = parseFloat($("#textGrossAmount_0").val());

    //Added by vinod mane on 12/10/2016
    var CashPaidAmt = $("#textTotalAmountReturnByCash_0").val();
    if (CashPaidAmt == "" || CashPaidAmt == "NaN") {
        CashPaidAmt = 0;
        $("#textTotalAmountReturnByCash_0").val(0);
    }
   
    var sumGrossAmount = $("#textGrossAmount_0").val();
    if (sumGrossAmount == "" || sumGrossAmount == "NaN") {
        sumGrossAmount = 0;
        $("#textGrossAmount_0").val(0);
    }
    //End

    var creditNoteAmt = sumGrossAmount - CashPaidAmt;

    $("#textTotalAmountReturnByCreditNote_0").val(Math.round(creditNoteAmt));


}




//$("[name='SalesInvoice[0].SKU_Code']").focusout(function ()
//{
//    Get_Sales_Order_Items_By_SKU_Code();
//});

