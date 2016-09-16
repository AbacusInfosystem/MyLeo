$(function () {
    $("#frmPurchaseInvoice").validate({
        rules: {
            "PurchaseInvoice.Purchase_Invoice_No": {
                required: true
            }
        },
        messages: {

            "PurchaseInvoice.Purchase_Invoice_No": {
                required: "Purchase Invoice No is required."
            }
        }
    });

});