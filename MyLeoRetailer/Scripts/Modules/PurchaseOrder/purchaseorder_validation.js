$(function () {
    $("#frmPurchaseOrder").validate({
        rules: {
            "PurchaseOrder.Purchase_Order_No": {
                required: true
            }
        },
        messages: {

            "PurchaseOrder.Purchase_Order_No": {
                required: "Purchase Order No is required."
            }
        }
    });

});