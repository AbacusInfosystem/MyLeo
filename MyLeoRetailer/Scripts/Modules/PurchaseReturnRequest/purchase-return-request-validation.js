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

});