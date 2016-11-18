$(document).ready(function () {

    if ($("#hdnSelecteddBranchId").val() != "") {

        $("#Branch").find(".autocomplete-text").trigger("focusout");
    }

    Add_Validation(0);

    $('#drpVendor_Id').change(function () {
        
        Get_Purchase_Invoice(this);

    });

    $("#btnSaveRequest").click(function () {

        $("#tblPurchaseReturnRequestItems").find("[id^='PurchaseReturnRequestItemRow_']").each(function (i, row) {
            Add_Validation(i);
        });

        if ($("#frmPurchaseReturnRequest").valid()) {
            
            if ($('#tblPurchaseReturnRequestItems tbody tr').length > 0) {
                
                       $("#frmPurchaseReturnRequest").attr("action", "/purchase-return-request/save-purchase-return-request");
                       $('#frmPurchaseReturnRequest').attr("method", "POST");
                       $('#frmPurchaseReturnRequest').submit();
                    
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