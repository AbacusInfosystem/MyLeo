$(function () {
    $("#frmPurchaseReturn").validate({
        rules: {
            "PurchaseReturn.Debit_Note_No": {
                required: true
            },

            "PurchaseReturn.Vendor_Id": {
                required: true
            },

            "PurchaseReturn.Transporter_Id": {
                required: true
            },

            "PurchaseReturn.Lr_No": {
                required: true
            },

            "PurchaseReturn.Logistics_Person_Name": {
                required: true
            },

            "PurchaseReturn.Discount_Percentage": {
                required: true,
                number: true
            },

            "PurchaseReturn.PurchaseReturns[0].Quantity": {
                required: true,
                digits: true
            }

        },
        messages: {

            "PurchaseReturn.Debit_Note_No": {
                required: "Debit note no is required."
            },

            "PurchaseReturn.Vendor_Id": {
                required: "Vendor name is required."
            },

            "PurchaseReturn.Transporter_Id": {
                required: "Transporter name is required."
            },

            "PurchaseReturn.Lr_No": {
                required: "LR No. is required."
            },

            "PurchaseReturn.Logistics_Person_Name": {
                required: "Logistics person name is required."
            },

            "PurchaseReturn.Discount_Percentage": {
                required: "Discount % is required.",
                number: "Enter only numbers"
            },

            "PurchaseReturn.PurchaseReturns[0].Quantity": {
                required: "Quantity is required.",
                digits: "Enter only digits"
            }            
        }
    });

    $("#textSKU_No_0").rules("add", { required: true, messages: { required: "SKU Code is required.", } });

});