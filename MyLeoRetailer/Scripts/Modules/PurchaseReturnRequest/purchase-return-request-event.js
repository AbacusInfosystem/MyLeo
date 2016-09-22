$(document).ready(function () {

    $("#textQuantity_0").rules("add", { required: true, digits: true, messages: { required: "Required field", digits: "Invalid quantity." } });

    $('#drpVendor_Id').change(function () {
        
        Get_Purchase_Invoice(this);

    });

    $("#btnSaveRequest").click(function () {
        if ($("#frmPurchaseReturnRequest").valid()) {
            
            if ($('#tblPurchaseReturnRequestItems tbody tr').length > 0)
            {
                if ($("#lblSKUMappingError").text() == "")
                {
                    $("#frmPurchaseReturnRequest").attr("action", "/purchase-return-request/save-purchase-return-request");
                    $('#frmPurchaseReturnRequest').attr("method", "POST");
                    $('#frmPurchaseReturnRequest').submit();

                }
               
            }
            
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