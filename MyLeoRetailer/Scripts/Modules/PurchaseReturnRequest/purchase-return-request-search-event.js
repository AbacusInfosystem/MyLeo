$(document).ready(function () {

    Get_Purchase_Return_Requests();

    $("#drpVendor_Id").change(function () {

        Get_Purchase_Return_Requests();

    });

    $("#btnView").click(function () {

        $("#frmPurchaseReturnRequest").attr("action", "/purchase-return-request/view-purchase-return-request");

        $("#frmPurchaseReturnRequest").attr("method", "POST");

        $("#frmPurchaseReturnRequest").submit();
    });


});
