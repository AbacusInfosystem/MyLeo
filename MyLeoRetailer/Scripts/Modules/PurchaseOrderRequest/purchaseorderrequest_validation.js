$(function () {
    $("#frmPurchaseOrderRequest").validate({
        rules: {
            "PurchaseOrderRequest.Vendor_Id": {
                required: true
            }
        },
        messages: {

            "PurchaseOrderRequest.Vendor_Id": {
                required: "Vendor Name is required."
            }
        }
    });

});