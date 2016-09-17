$(function () {
    $("#frmPurchaseReturn").validate({
        rules: {
            "PurchaseReturn.Debit_Note_No": {
                required: true
            }
        },
        messages: {

            "PurchaseReturn.Debit_Note_No": {
                required: "Debit note no is required."
            }
        }
    });

});