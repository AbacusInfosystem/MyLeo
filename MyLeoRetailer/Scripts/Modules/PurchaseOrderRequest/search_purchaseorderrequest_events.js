$(function () {
    
    Get_Purchase_Order_Requests();

    $(document).on('change', '[name="Purchase_Order_Request_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnPurchaseOrderRequestId").val(this.value);
            document.getElementById('btnEditPurchaseOrderRequest').disabled = false;
        }
    });
     
    $("#btnCreatePurchaseOrderRequest").click(function () {
        $("#frmPurchaseOrderRequest").attr("action", "/PurchaseOrderRequest/Index");
        $("#frmPurchaseOrderRequest").submit();
    });
});