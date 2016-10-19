$(document).ready(function () {

    //document.getElementById("btnEditPurchaseOrderRequest").disabled = true;
    
    Get_Purchase_Order_Requests();

    $(document).on('change', '[name="Purchase_Order_Request_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnPurchaseOrderRequestId").val(this.value);
            document.getElementById("btnEditPurchaseOrderRequest").disabled = false;
            //document.getElementById("btnCreatePurchaseOrderRequest").disabled = true;
        }
    });

    $("#drpVendor_Id").change(function () {

        Get_Purchase_Order_Requests();
        $('.edit').each(function () {
            $(this).attr('disabled', 'disabled');
        });

    });
     
    $("#btnCreatePurchaseOrderRequest").click(function () {
        $("#frmPurchaseOrderRequest").attr("action", "/PurchaseOrderRequest/Index");
        $("#frmPurchaseOrderRequest").submit();
    });


    $("#btnEditPurchaseOrderRequest").click(function () {
        $("#frmPurchaseOrderRequest").attr("action", "/PurchaseOrderRequest/Get_Purchase_Order_Request_By_Id");
        $("#frmPurchaseOrderRequest").submit();
    });
});