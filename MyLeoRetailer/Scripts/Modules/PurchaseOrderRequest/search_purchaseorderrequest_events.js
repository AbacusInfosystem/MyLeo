﻿$(document).ready(function () {

    document.getElementById("btnEditPurchaseOrderRequest").disabled = true;
    
    Get_Purchase_Order_Requests();

    $(document).on('change', '[name="Purchase_Order_Request_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnPurchaseOrderRequestId").val(this.value);
            document.getElementById("btnEditPurchaseOrderRequest").disabled = false;
        }
    });

    
   

    $("#drpVendor_Id").change(function () {

        Get_Purchase_Order_Requests();

    });
     
    $("#btnCreatePurchaseOrderRequest").click(function () {
        $("#frmPurchaseOrderRequest").attr("action", "/PurchaseOrderRequest/Index/");
        $('#frmPurchaseOrderRequest').attr("method", "POST");
        $("#frmPurchaseOrderRequest").submit();
    });


    $("#btnEditPurchaseOrderRequest").click(function () {
        $("#frmPurchaseOrderRequest").attr("action", "/PurchaseOrderRequest/Get_Purchase_Order_Request_By_Id/");
        $('#frmPurchaseOrderRequest').attr("method", "POST");
        $("#frmPurchaseOrderRequest").submit();
    });
});