$(document).ready(function () {

    $('#dtpInvoice_Date').datepicker({});

});


$(function ()
{


    $("[name='SalesInvoice.Mobile']").focusout(function ()
    {
        Get_Customer_Name_By_Mobile_No();
    });


    $("#btnSaveSalesOrder").click(function ()
    {
   
        $("#frmSalesOrder").attr("action", "/SalesOrder/Insert_SalesOrder/");

        $('#frmSalesOrder').attr("method", "POST");

        $('#frmSalesOrder').submit();

    });

});

function CalculateTotal()
{

    var sumQuantity = 0;
    var sumMRPAmount = 0;
    var sumDiscountAmount = 0;
    var sumGrossAmount = 0;

    var tr = $("#tblSalesOrderItems").find('[id^="SalesOrderItemRow_"]');


    if (tr.size() > 0)
    {
        for (var i = 0; i < tr.size() ; i++)
        {
            var Qty = parseFloat($("#tblSalesOrderItems").find('[id="textQuantity_' + i + '"]').val());
            var MRP = parseFloat($("#tblSalesOrderItems").find('[id="textMRP_Price_' + i + '"]').val());
            var Discount = parseFloat($("#tblSalesOrderItems").find('[id="textDiscount_Percentage_' + i + '"]').val());
            var DiscountAmt = (Discount == "" || Discount == undefined) ? 0 : parseFloat((Qty * MRP * Discount) / 100);
            $("#tblSalesOrderItems").find('[id="textSalesOrder_Discount_Amount_' + i + '"]').val(DiscountAmt);
            var Amount = parseFloat(MRP * Qty - DiscountAmt);
            $("#tblSalesOrderItems").find('[id="textAmount_' + i + '"]').val(Amount);
          
            sumQuantity = sumQuantity + Qty;
            sumMRPAmount = sumMRPAmount + MRP;
            sumDiscountAmount = sumDiscountAmount + DiscountAmt;
            sumGrossAmount = sumGrossAmount + Amount;

        }
    }

    $("#textTotalQuantity_0").val(sumQuantity);
    $("#textMRPAmount_0").val(sumMRPAmount.toFixed(2));
    $("#textDiscountAmount_0").val(sumDiscountAmount.toFixed(2));
    $("#textGrossAmount_0").val(sumGrossAmount.toFixed(2));
    
}


function CalculateTax() {
   
    var netAmt = 0;

    var tax = parseFloat($("#textTaxPercentage_0").val());
    var sumGrossAmount = parseFloat($("#textGrossAmount_0").val());
   

    var taxAmt = (tax == "" || tax == undefined) ? 0 : parseFloat((sumGrossAmount * tax) / 100);
    $("#tblSalesOrderItems").find("textTaxAmount_0").val(taxAmt);

    var netAmt_temp = taxAmt + sumGrossAmount;

    var roundedDecimal = netAmt_temp.toFixed(2);

    var intPart = Math.floor(roundedDecimal);
   
    var fracPart = parseFloat((roundedDecimal - intPart), 2);
    
    var roundOff = parseFloat(netAmt_temp.toString().split(".")[1]);

    var netAmt = netAmt_temp - fracPart;

    //var netAmt = Math.round(0.2);

    $("#textTaxAmount_0").val(taxAmt.toFixed(2));
    $("#textRoundOff_0").val(fracPart.toFixed(2));
    $("#textNETAmount_0").val(Math.round(netAmt));

}



//$("[name='SalesInvoice[0].SKU_Code']").focusout(function ()
//{
//    Get_Sales_Order_Items_By_SKU_Code();
//});