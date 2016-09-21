$(function () {
    $("#frmPurchaseReturn").validate({
        rules: {
            "PurchaseReturn.Debit_Note_No": {
                required: true
            },

            "PurchaseReturn.Lr_No": {
                required: true
            },

            "PurchaseReturn.Logistics_Person_Name": {
                required: true
            },

            "PurchaseReturn.Discount_Percentage": {
                digits: true
            }
        },
        messages: {

            "PurchaseReturn.Debit_Note_No": {
                required: "Debit note no is required."
            },

            "PurchaseReturn.Lr_No": {
                required: "LR No. is required."
            },

            "PurchaseReturn.Logistics_Person_Name": {
                required: "Logistics person name is required."
            },

            "PurchaseReturn.Discount_Percentage": {
                digits: "Enter only digits"
            }
        }
    });

});