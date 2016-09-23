$(document).ready(function () {

    $("#frmPurchaseReturnRequest").validate({
        rules: {
            "PurchaseReturnRequest.Vendor_Id": {
                required: true
            },
            "PurchaseReturnRequest.Purchase_Invoice_Id": {
                required: true
            },
            "PurchaseReturnRequest.Discount_Percentage": {
                number: true
            },
            
        },
        messages: {

            "PurchaseReturnRequest.Vendor_Id": {
                required: "Vendor is required."
            },
            "PurchaseReturnRequest.Purchase_Invoice_Id": {
                required: "Purchase invoice no is required."
            },
            "PurchaseReturnRequest.Discount_Percentage": {
                number: "Invalid discount."
            },
            

        }
    });

    jQuery.validator.addMethod("checkSKUExist", function (value, element) {
        var result = true;
        var id = $(element).attr('id');
        id = id.replace("textSKU_No_", "");
     
        $("#tblPurchaseReturnRequestItems").find("[id^='PurchaseReturnRequestItemRow_']").each(function (j, row) {

            if (id != j && $(element).val() == $("#textSKU_No_" + j).val()) {
                result = false;
            }
        });

        return result;
    }, "Already mapped.");


});