$(function () {

    $("#frmPurchaseInvoice").validate({       

        rules: {
            //"PurchaseInvoice.Purchase_Invoice_No": {
            //    required: true
            //},

            "PurchaseInvoice.Vendor_Id": {
                required: true
            },

            "PurchaseInvoice.Transporter_Id": {
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
                required: true,
                number: true
            }
            //},

            //"PurchaseInvoice.PurchaseInvoices[0].Quantity": {
            //    required: true,
            //    digits: true
            //},

            //"PurchaseInvoice.PurchaseInvoices[0].SKU_Code": {
            //    required: true
            //},

            //"PurchaseInvoice.PurchaseInvoices[0].Purchase_Order_No": {
            //    required: true
            //}

        },
        messages: {

            //"PurchaseInvoice.Purchase_Invoice_No": {
            //    required: "Purchase Invoice No. is required."
            //},

            "PurchaseInvoice.Vendor_Id": {
                required: "Vendor name is required."
            },

            "PurchaseInvoice.Transporter_Id": {
                required: "Transporter name is required."
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
                required: "Discount % is required.",
                number: "Enter only numbers"
            }
            //},

            //"PurchaseInvoice.PurchaseInvoices[0].Quantity": {
            //    required: "Quantity is required.",
            //    digits: "Enter only digits"
            //},

            //"PurchaseInvoice.PurchaseInvoices[0].SKU_Code": {
            //    required: "SKU code is required."
            //},

            //"PurchaseInvoice.PurchaseInvoices[0].Purchase_Order_No": {
            //    required: "PO No. is required."
            //}
        }
    });

    jQuery.validator.addMethod("checkSKUExist", function (value, element) {
        var result = true;
        var id = $(element).attr('id')
        id = id.replace("hdnSKU_No_", "");

        $("#tblPurchaseInvoiceItems").find("[id^='PurchaseInvoiceItemRow_']").each(function (j, row) {

            if (id != j && $(element).val() == $("#hdnSKU_No_" + j).val()) {

                result = false;
            }
        });

        return result;
    }, "Already mapped.");
   
});