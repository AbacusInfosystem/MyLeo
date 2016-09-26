$(document).ready(function () {

    document.getElementById("btnEditPurchaseOrder").disabled = true;
    document.getElementById("btnViewPurchaseOrder").disabled = true;
    
    Get_Purchase_Orders();

    $(document).on('change', '[name="Purchase_Order_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnPurchaseOrderId").val(this.value);
            document.getElementById('btnEditPurchaseOrder').disabled = false;
            document.getElementById('btnViewPurchaseOrder').disabled = false;

        }
    });

    $("[name='Filter.Purchase_Order_No']").focusout(function () {
        Get_Purchase_Orders();
    });


    $("#btnCreatePurchaseOrder").click(function () {
        $("#frmPurchaseOrder").attr("action", "/PurchaseOrder/Index");
        $("#frmPurchaseOrder").submit();
    });

    $("#btnEditPurchaseOrder").click(function () {
        $("#frmPurchaseOrder").attr("action", "/PurchaseOrder/Get_Purchase_Order_By_Id");
        $("#frmPurchaseOrder").submit();
    });

    $("#btnViewPurchaseOrder").click(function () {
        $("#frmPurchaseOrder").attr("action", "/PurchaseOrder/Get_Purchase_Order_Details");
        $("#frmPurchaseOrder").submit();
    });

});