$(function () {
    $("#frmPurchaseOrder").validate({
        rules: {
            "PurchaseOrder.Purchase_Order_No": {
                required: true
            },
            //Addition
            "PurchaseOrder.Purchase_Price": {
                number: true
            },
            "PurchaseOrder.Size_Difference": {
                number: true
            },
            //End
        },
        messages: {

            "PurchaseOrder.Purchase_Order_No": {
                required: "Purchase Order No is required."
            },
            //Addition
            "PurchaseOrder.Purchase_Price": {
                number: "Please enter a valid number."
            },
            "PurchaseOrder.Size_Difference": {
                number: "Please enter a valid number."
            },
            //End
        }
    });

});