$(function () {

    if ($("[name='PurchaseOrder.Purchase_Order_Id']").val() == "" || $("[name='PurchaseOrder.Purchase_Order_Id']").val() == 0) {
        document.getElementById("btnCanclePurchaseOrder").disabled = false;
    }
    else {
        document.getElementById('btnCanclePurchaseOrder').disabled = true;
    }

    $("#btnSavePurchaseOrder").click(function () {
        if ($("#frmPurchaseOrder").valid()) {
            if ($("[name='PurchaseOrder.Purchase_Order_Id']").val() == "" || $("[name='PurchaseOrder.Purchase_Order_Id']").val() == 0) {
                $("#frmPurchaseOrder").attr("action", "/PurchaseOrder/Insert_Purchase_Order");
            }
            else {
                $("#frmPurchaseOrder").attr("action", "/PurchaseOrder/Update_Purchase_Order");
            }
            $('#frmPurchaseOrder').attr("method", "POST");
            $('#frmPurchaseOrder').submit();

        }
    });

    

    $("#btnAddSizesPurchaseOrder").click(function () {               
        Get_Sizes();
    });

    $("#btnAddDetailsPurchaseOrder").click(function () {
        AddPurchaseOrderDetails();

        //CalculateRowAmount();

    });
           
       
});