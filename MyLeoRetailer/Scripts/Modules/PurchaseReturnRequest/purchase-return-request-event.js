$(document).ready(function () {

    $('#drpVendor_Id').change(function () {
        
        Get_Purchase_Invoice(this);

    });

    $("#btnSaveRequest").click(function () {
        if ($("#frmPurchaseReturnRequest").valid()) {
            
            $("#frmPurchaseReturnRequest").attr("action", "/purchase-return-request/save-purchase-return-request");
            $('#frmPurchaseReturnRequest').attr("method", "POST");
            $('#frmPurchaseReturnRequest').submit();
          
        }
    });

    
    $("#textGrossAmount_0").change(function () {
        CalculateTax();
    });

    $("#textTaxPercentage_0").change(function () {
        CalculateTax();
    });

    $("#textDiscountPercentage_0").keyup(function () {
        CalculateDiscount();
    });
    $("#textDiscountPercentage_0").change(function () {
        CalculateDiscount();
    });


});