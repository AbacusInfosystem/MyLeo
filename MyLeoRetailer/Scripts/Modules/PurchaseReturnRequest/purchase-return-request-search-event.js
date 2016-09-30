$(document).ready(function () {


    document.getElementById('btnEditPurchaseReturnRequest').disabled = true;

    Get_Purchase_Return_Requests();

    $(document).on('change', '[name="Purchase_Return_Request_List"]', function (event) {
        if ($(this).prop('checked')) {
            document.getElementById('btnEditPurchaseReturnRequest').disabled = false;
            document.getElementById('btnCreate').disabled = true;
        }
    });

   
    //$("#btnEditPurchaseReturnRequest").click(function () {
    //    $("#frmPurchaseReturnRequest").attr("action", "/PurchaseReturnRequest/Get_Purchase_Return_Requests_By_Id/");
    //    $('#frmPurchaseReturnRequest').submit();
    //});


    $("#drpVendor_Id").change(function () {

        Get_Purchase_Return_Requests();

    });


});
