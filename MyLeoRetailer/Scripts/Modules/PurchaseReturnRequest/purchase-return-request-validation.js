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
            "PurchaseReturnRequest.Branch_Id": {
                required: true
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
            "PurchaseReturnRequest.Branch_Id": {
                required: "Branch is required."
            },

        }
    });

    jQuery.validator.addMethod("checkSKUExist", function (value, element) {
        var result = true;
        var id = $(element).attr('id');
        id = id.replace("hdnSKU_No_", "");
     
        $("#tblPurchaseReturnRequestItems").find("[id^='PurchaseReturnRequestItemRow_']").each(function (j, row) {

            if (id != j && $(element).val() == $("#hdnSKU_No_" + j).val()) {
                result = false;
            }
        });

        return result;
    }, "Already mapped.");

    jQuery.validator.addMethod("checkBarcodeExist", function (value, element) {

        debugger;

        var result = true;

        var id = $(element).attr('id');

        id = id.replace("textBarcode_No_", "");

        $("#tblPurchaseReturnRequestItems").find("[id^='PurchaseReturnRequestItemRow_']").each(function (j, row) {

            if ($(element).val() != "" && $("#textBarcode_No_" + j).val() != "") {

                if (id != j && $(element).val() == $("#textBarcode_No_" + j).val()) {
                    result = false;
                }

            }
        });

        return result;

    }, "Already mapped.");



});