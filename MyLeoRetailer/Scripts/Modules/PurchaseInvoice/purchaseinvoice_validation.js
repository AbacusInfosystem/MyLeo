$(function () {

    $("#frmPurchaseInvoice").validate({       

        rules: {
            "PurchaseInvoice.Purchase_Invoice_No": {
                required: true
            },

            "PurchaseInvoice.Against_Form": {
                required: true,
                digits: true
            },

            "PurchaseInvoice.Against_Form_No": {
                required: true
            },

            "PurchaseInvoice.Purchase_Packing_No": {
                required: true
            },

            "PurchaseInvoice.Lr_No": {
                required: true
            },

            "PurchaseInvoice.Discount_Percentage": {
                digits: true
            }

        },
        messages: {

            "PurchaseInvoice.Purchase_Invoice_No": {
                required: "Purchase Invoice No. is required."
            },

            "PurchaseInvoice.Against_Form": {
                required: "Against Form is required.",
                digits: "Enter only digits"
            },

            "PurchaseInvoice.Against_Form_No": {
                required: "Against Form No. is required."
            },

            "PurchaseInvoice.Purchase_Packing_No": {
                required: "Purchase Packing No. is required."
            },

            "PurchaseInvoice.Lr_No": {
                required: "LR No. is required."
            },

            "PurchaseInvoice.Discount_Percentage": {
                digits: "Enter only digits"
            }
        }
    });    

});