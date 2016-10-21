$(document).ready(function () {


    document.getElementById('btnView').disabled = true;

    Get_Purchase_Return_Requests();

    $(document).on('change', '[name="Purchase_Return_Request_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnPurchase_Return_Request_Id").val(this.value);
            document.getElementById('btnView').disabled = false;
        }
    });

   
    $("#btnCreate").click(function () {
        $("#frmPurchaseReturnRequest").attr("action", "/purchase-return-request/create-purchase-return-request");

        $("#frmPurchaseReturnRequest").attr("method", "POST");

        $('#frmPurchaseReturnRequest').submit();
    });


    $("#drpVendor_Id").change(function () {

        Get_Purchase_Return_Requests();

    });

    $("#btnView").click(function () {

        $("#frmPurchaseReturnRequest").attr("action", "/purchase-return-request/view-purchase-return-request");

        $("#frmPurchaseReturnRequest").attr("method", "POST");

        $("#frmPurchaseReturnRequest").submit();
    });


});
