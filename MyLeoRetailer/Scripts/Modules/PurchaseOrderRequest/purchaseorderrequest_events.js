$(function () {
        
    $("#btnSavePurchaseOrderRequest").click(function () {
        //if ($("#frmPurchaseOrderRequest").valid()) {
        if ($("[name='PurchaseOrderRequest.Purchase_Order_Request_Id']").val() == "" || $("[name='PurchaseOrderRequest.Purchase_Order_Request_Id']").val() == 0) {
            $("#frmPurchaseOrderRequest").attr("action", "/PurchaseOrderRequest/Insert_Purchase_Order_Request");
            $('#frmPurchaseOrderRequest').attr("method", "POST");
            $('#frmPurchaseOrderRequest').submit();
        }
        //}
    });
    
    $("#btnAddSizesPurchaseOrderRequest").click(function () {
        Get_Sizes();
    });

    $("#btnAddDetailsPurchaseOrderRequest").click(function () {
        AddPurchaseOrderRequestDetails();
        
    });


});